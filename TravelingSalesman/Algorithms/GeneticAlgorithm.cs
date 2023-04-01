using System.Text;
using TravelingSalesman.Chromosomes;
using TravelingSalesman.Factories;
using TravelingSalesman.Factories.Interfaces;
using TravelingSalesman.MatingStrategies;
using TravelingSalesman.Mutations;
using TravelingSalesman.TSPFitness;

namespace TravelingSalesman.Algorithms
{
    public class GeneticAlgorithm
    {
        private readonly Random rand;
        private readonly IMatingStrategy matingStrategy;
        private readonly TSPFitnessCalculator fitnessCalculator;
        private readonly Chromosome[] population;
        private readonly PopulationFactory populationFactory;
        private readonly ChromosomeSelector chromosomeSelector;
        private readonly IMutation mutation;
        private string? LogPath;
        private int iterations = 0;

        public int LogLevel { get; set; } = 0;

        public double ShortestCycleLength { private set; get; } = double.MaxValue;
        public Chromosome ShortestCycleChromosome { private set; get; }

        private readonly StringBuilder log = new StringBuilder();

        public GeneticAlgorithm(int chromosomeLength, int populationSize,
            IChromosomeFactory factory, IMatingStrategy matingStrategy,
            IMutation mutation, TSPFitnessCalculator fitnessCalculator,
            Random rand, string? logPath = null)
        {
            populationFactory = new(factory);
            population = populationFactory.CreatePopulation(populationSize, chromosomeLength);
            this.matingStrategy = matingStrategy;
            this.fitnessCalculator = fitnessCalculator;
            chromosomeSelector = new(fitnessCalculator, rand);
            this.mutation = mutation;
            this.rand = rand;
            ShortestCycleChromosome = population[0];
            LogPath = logPath;

            if (LogPath is not null)
            {
                AddLogTitle();
            }
        }

        public void UpdatePopulation(double crossoverProbability, double mutationProbability, double eliteSize)
        {
            Chromosome[] parents = new Chromosome[population.Length];

            int eliteCount = (int)(population.Length * eliteSize);
            Chromosome[] elite = population.OrderByDescending(fitnessCalculator.CalculateFitness).Take(eliteCount).ToArray();

            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = chromosomeSelector.SelectForMating(population);
            }

            for (int i = 0; i < population.Length - eliteCount; i++)
            {
                if (rand.NextDouble() > crossoverProbability)
                    continue;

                var parent1 = parents[rand.Next(parents.Length)];
                var parent2 = parents[rand.Next(parents.Length)];

                population[i] = matingStrategy.ProduceSingleOffspring(parent1, parent2);
            }

            for (int i = 0; i < population.Length - eliteCount; i++)
            {
                if (rand.NextDouble() <= mutationProbability)
                {
                    population[i] = mutation.Mutate(population[i]);
                }
            }

            for (int i = 0; i < eliteCount; i++)
            {
                population[i + population.Length - eliteCount] = elite[i];
            }
        }

        public void Run(int maxIterations, double crossoverProbability, double mutationProbability, double eliteSize = 0.25)
        {
            for (int i = 0; i < maxIterations; i++)
            {
                if (LogPath is not null)
                    LogProgress(iterations + i);

                UpdatePopulation(crossoverProbability, mutationProbability, eliteSize);

                var (chromosome, cycleLength) = GetShortestCycleChromosome();
                if (cycleLength < ShortestCycleLength)
                {
                    ShortestCycleLength = cycleLength;
                    ShortestCycleChromosome = chromosome;
                }
            }

            iterations += maxIterations;

            if (LogPath is not null)
            {
                File.AppendAllText(LogPath!, log.ToString());
                log.Clear();
            }

            if (LogLevel >= 1)
                Console.WriteLine($"Shortest cycle length: {ShortestCycleLength}");

            if (LogLevel >= 2)
                Console.WriteLine($"Shortest cycle: {ShortestCycleChromosome}");
        }

        public void RunDHMILC(double step)
        {
            double crossoverProbability = 0;
            double mutationProbability = 1;
            double eliteSize = 0.25;
            int i = 0;

            while (crossoverProbability <= 1 && mutationProbability >= 0)
            {
                if (LogPath is not null)
                    LogProgress(i);

                UpdatePopulation(crossoverProbability, mutationProbability, eliteSize);

                crossoverProbability += step;
                mutationProbability -= step;
                i++;
            }

            if (LogPath is not null)
                File.AppendAllText(LogPath!, log.ToString());
        }

        private void LogProgress(int iteration)
        {
            if (LogLevel >= 0)
            {
                var (chromosome, cycleLength) = GetShortestCycleChromosome();
                double averageCycleLength = population.Average(
                    x => fitnessCalculator.UnderlyingGraph.GetCycleLength(x.Genomes));
                log.Append($"it = {iteration}; genomes = {chromosome}; min = {cycleLength}; avg = {averageCycleLength};{Environment.NewLine}");
            }
        }

        private void AddLogTitle()
        {
            log.Append($"{matingStrategy} with {mutation}{Environment.NewLine}");
        }

        public (Chromosome, double) GetShortestCycleChromosome()
        {
            double minCycleLength = double.MaxValue;
            Chromosome minCycleLengthChromosome = population[0];
            foreach (var chromosome in population)
            {
                double cycleLength = fitnessCalculator.UnderlyingGraph.GetCycleLength(chromosome.Genomes);
                if (cycleLength < minCycleLength)
                {
                    minCycleLength = cycleLength;
                    minCycleLengthChromosome = chromosome;
                }
            }

            return (minCycleLengthChromosome, minCycleLength);
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            for (int i = 0; i < population.Length; i++)
            {
                sb.Append($"{i.ToString()} - {population[i].ToString()}");
                double cycleLength = fitnessCalculator.UnderlyingGraph.GetCycleLength(population[i].Genomes);
                sb.Append($" (path length = {cycleLength})\n");
            }

            return sb.ToString();
        }
    }
}
