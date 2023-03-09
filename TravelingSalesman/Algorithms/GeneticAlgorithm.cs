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
        private readonly IMutation mutation;

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

        // This is the "pure" version of the algorithm due to J.-Y. Potvin
        // A generalization for different numbers of mating chromosomes would be nice
        public void UpdatePopulation1(double mutationRate)
        {
            Chromosome[] parents = new Chromosome[population.Length];

            for (int i = 0; i < population.Length; i++)
            {
                parents[i] = chromosomeSelector.SelectForMating(population);
            }

            Chromosome[] updatedPopulation = new Chromosome[population.Length];

            for (int i = 0; i < population.Length; i += 2)
            {
                var parent1 = parents[rand.Next(population.Length)];
                var parent2 = parents[rand.Next(population.Length)];

                var (offspring1, offspring2) = matingStrategy.ProduceOffspring(parent1, parent2);
                updatedPopulation[i] = offspring1;
                updatedPopulation[i + 1] = offspring2;
            }

            for (int i = 0; i < population.Length; i++)
            {
                if (rand.NextDouble() <= mutationRate)
                {
                    updatedPopulation[i] = mutation.Mutate(updatedPopulation[i]);
                }
            }

            Array.Copy(updatedPopulation, population, population.Length);
        }

        // This is the algorithm due to K.D.
        public void UpdatePopulation2(double mutationRate)
        {
            Chromosome[] updatedPopulation = new Chromosome[population.Length];

            for (int i = 0; i < updatedPopulation.Length; i++)
            {
                Chromosome parent1 = chromosomeSelector.DrawRandomChromosome(population);
                Chromosome parent2 = chromosomeSelector.DrawRandomChromosome(population);

                updatedPopulation[i] = matingStrategy.ProduceSingleOffspring(parent1, parent2);
            }

            for (int i = 0; i < population.Length; i++)
            {
                if (rand.NextDouble() <= mutationRate)
                {
                    updatedPopulation[i] = mutation.Mutate(population[i]);
                }
            }

            Array.Copy(updatedPopulation, population, population.Length);
        }

        public void Run(int iterations, double mutationRate)
        {
            for (int i = 0; i < iterations; i++)
            {
                if (LogPath is not null)
                    LogProgress(i);

                UpdatePopulation1(mutationRate);
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
