using System.Text;
using TravelingSalesman.Chromosomes;
using TravelingSalesman.Factories;
using TravelingSalesman.Factories.Interfaces;
using TravelingSalesman.MatingStrategies;
using TravelingSalesman.Mutations;
using TravelingSalesman.Selectors;
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
        private readonly string? logPath;
        private readonly double? expectedShortestCycleLength;

        private int iterations = 0;

        public int LogLevel { get; set; } = 0;

        public double ShortestCycleLength { private set; get; } = double.MaxValue;
        public Chromosome ShortestCycleChromosome { private set; get; }

        private readonly StringBuilder log = new StringBuilder();

        public GeneticAlgorithm(int chromosomeLength, int populationSize,
            IChromosomeFactory factory, IMatingStrategy matingStrategy,
            IMutation mutation, TSPFitnessCalculator fitnessCalculator,
            Random rand, double? expectedShortestCycleLength = null, string? logPath = null)
        {
            populationFactory = new(factory);
            population = populationFactory.CreatePopulation(populationSize, chromosomeLength);
            this.matingStrategy = matingStrategy;
            this.fitnessCalculator = fitnessCalculator;
            chromosomeSelector = new(fitnessCalculator, rand);
            this.mutation = mutation;
            this.rand = rand;
            ShortestCycleChromosome = population[0];
            this.expectedShortestCycleLength = expectedShortestCycleLength;
            this.logPath = logPath;

            if (this.logPath is not null)
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
                if (logPath is not null)
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

            if (logPath is not null)
            {
                File.AppendAllText(logPath!, log.ToString());
                log.Clear();
            }

            if (LogLevel >= 1)
            {
                Console.WriteLine($"Shortest cycle length: {ShortestCycleLength}");
                if (expectedShortestCycleLength is not null)
                {
                    double score = ShortestCycleLength / (double)expectedShortestCycleLength - 1;
                    Console.WriteLine($"Difference: {string.Format("{0:0.00}", score * 100)}%");
                }
            }

            if (LogLevel >= 2)
                Console.WriteLine($"Shortest cycle: {ShortestCycleChromosome}");
        }

        public int RunUntilOptimum(double crossoverProbability, double mutationProbability, double eliteSize = 0.25, double tolerance = 0.01, int maxIterations = (int)1e6)
        {
            if (expectedShortestCycleLength is null)
                return -1;

            int i = 0;
            while (ShortestCycleLength > expectedShortestCycleLength! * (1 + tolerance) && ++i < maxIterations)
            {
                if (logPath is not null)
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

            if (logPath is not null)
            {
                File.AppendAllText(logPath!, log.ToString());
                log.Clear();
            }

            if (LogLevel >= 1)
            {
                Console.WriteLine($"Shortest cycle length: {ShortestCycleLength}");
                if (expectedShortestCycleLength is not null)
                {
                    double score = ShortestCycleLength / (double)expectedShortestCycleLength - 1;
                    if (score > tolerance)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Difference: {string.Format("{0:0.00}", score * 100)}%");
                    Console.ResetColor();
                }
                Console.WriteLine($"Iterations ran: {i}");
            }

            if (LogLevel >= 2)
                Console.WriteLine($"Shortest cycle: {ShortestCycleChromosome}");

            return i;
        }

        public void RunDHMILC(double step, double eliteSize = 0.25)
        {
            double crossoverProbability = 0;
            double mutationProbability = 1;
            int i = 0;

            while (crossoverProbability <= 1 && mutationProbability >= 0)
            {
                if (logPath is not null)
                    LogProgress(iterations + i);

                UpdatePopulation(crossoverProbability, mutationProbability, eliteSize);


                var (chromosome, cycleLength) = GetShortestCycleChromosome();
                if (cycleLength < ShortestCycleLength)
                {
                    ShortestCycleLength = cycleLength;
                    ShortestCycleChromosome = chromosome;
                }

                iterations += i;

                crossoverProbability += step;
                mutationProbability -= step;
                i++;
            }

            if (logPath is not null)
            {
                File.AppendAllText(logPath!, log.ToString());
                log.Clear();
            }

            if (LogLevel >= 1)
            {
                Console.WriteLine($"Shortest cycle length: {ShortestCycleLength}");
                if (expectedShortestCycleLength is not null)
                {
                    double score = ShortestCycleLength / (double)expectedShortestCycleLength - 1;
                    Console.WriteLine($"Difference: {string.Format("{0:0.00}", score * 100)}%");
                }
            }

            if (LogLevel >= 2)
                Console.WriteLine($"Shortest cycle: {ShortestCycleChromosome}");
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
            log.Append($"{matingStrategy} & {mutation}{Environment.NewLine}");
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
