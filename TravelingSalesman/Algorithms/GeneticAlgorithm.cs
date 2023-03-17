using System.Text;
using TravelingSalesman.Chromosomes;
using TravelingSalesman.Factories;
using TravelingSalesman.Factories.Interfaces;
using TravelingSalesman.MatingStrategies;
using TravelingSalesman.Mutations;
using TravelingSalesman.TSPFitness;

namespace TravelingSalesman.Algorithms
{
    internal class GeneticAlgorithm
    {
        static readonly Random rand = new();
        private readonly IMatingStrategy matingStrategy;
        private readonly TSPFitnessCalculator fitnessCalculator;
        private readonly Chromosome[] population;
        private readonly PopulationFactory populationFactory;
        private readonly ChromosomeSelector chromosomeSelector;
        internal readonly IMutation mutation;

        public string? LogPath { get; set; }
        public int LogLevel { get; set; } = 0;

        private readonly StringBuilder log = new StringBuilder();

        public GeneticAlgorithm(int chromosomeLength, int populationSize,
            IChromosomeFactory factory, IMatingStrategy matingStrategy,
            IMutation mutation, TSPFitnessCalculator fitnessCalculator)
        {
            populationFactory = new(factory);
            population = populationFactory.CreatePopulation(populationSize, chromosomeLength);
            this.matingStrategy = matingStrategy;
            this.fitnessCalculator = fitnessCalculator;
            chromosomeSelector = new(fitnessCalculator);
            this.mutation = mutation;
        }

        public void UpdatePopulation(double crossoverProbability, double mutationProbability)
        {
            Chromosome[] parents = new Chromosome[population.Length / 2];

            for (int i = 0; i < population.Length / 2; i++)
            {
                parents[i] = chromosomeSelector.SelectForMating(population);
            }

            for(int i = 0; i < population.Length; i++)
            {
                if (rand.NextDouble() > crossoverProbability)
                    continue;

                var parent1 = parents[rand.Next(parents.Length)];
                var parent2 = parents[rand.Next(parents.Length)];

                population[i] = matingStrategy.ProduceSingleOffspring(parent1, parent2);
            }

            for(int i = 0; i < population.Length; i++)
            {
                if(rand.NextDouble() <= mutationProbability)
                {
                    population[i] = mutation.Mutate(population[i]);
                }
            }
        }

        public void Run(int maxIterations, double crossoverProbability, double mutationProbability)
        {
            for (int i = 0; i < maxIterations; i++)
            {
                if (LogPath is not null)
                    LogProgress(i);

                UpdatePopulation(crossoverProbability, mutationProbability);
            }

            if (LogPath is not null)
                File.AppendAllText(LogPath!, log.ToString());
        }

        public void RunDHMILC(double step)
        {
            double crossoverProbability = 0;
            double mutationProbability = 1;
            int i = 0;

            while(crossoverProbability <= 1 && mutationProbability >= 0)
            {
                if (LogPath is not null)
                    LogProgress(i);

                UpdatePopulation(crossoverProbability, mutationProbability);

                crossoverProbability += step;
                mutationProbability -= step;
                i++;
            }

            if (LogPath is not null)
                File.AppendAllText(LogPath!, log.ToString());
        }

        private void LogProgress(int iteration)
        {
            switch (LogLevel)
            {
                case 0:
                    var (chromosome, cycleLength) = GetLongestCycleChromosome();
                    log.Append($"{iteration}: {chromosome} {cycleLength} {Environment.NewLine}");

                    break;

                default:
                    break;
            }
        }

        private (Chromosome, double) GetLongestCycleChromosome()
        {
            double maxCycleLength = 0;
            Chromosome maxCycleLengthChromosome;
            foreach (var chromosome in population)
            {
                double cycleLength = fitnessCalculator.UnderlyingGraph.GetCycleLength(chromosome.Genomes);
                if (cycleLength > maxCycleLength)
                {
                    maxCycleLength = cycleLength;
                    maxCycleLengthChromosome = chromosome;
                }
            }

            maxCycleLengthChromosome = population[^1];

            return (maxCycleLengthChromosome, maxCycleLength);
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
