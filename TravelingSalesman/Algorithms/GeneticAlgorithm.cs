using System.Text;
using TravelingSalesman.Chromosomes;
using TravelingSalesman.Factories;
using TravelingSalesman.Factories.Interfaces;
using TravelingSalesman.MatingStrategies;
using TravelingSalesman.TSPFitness;

namespace TravelingSalesman.Algorithms
{
    internal class GeneticAlgorithm
    {
        static readonly Random rand = new();
        readonly IMatingStrategy matingStrategy;
        readonly TSPFitnessCalculator fitnessCalculator;
        private Chromosome[] population;
        readonly PopulationFactory populationFactory;
        readonly ChromosomeSelector chromosomeSelector;

        public GeneticAlgorithm(int ChromosomeLength, int populationSize,
            IChromosomeFactory factory, IMatingStrategy matingStrategy,
            TSPFitnessCalculator fitnessCalculator)
        {
            populationFactory = new(factory);
            population = populationFactory.CreatePopulation(populationSize, ChromosomeLength);
            this.matingStrategy = matingStrategy;
            this.fitnessCalculator = fitnessCalculator;
            chromosomeSelector = new(fitnessCalculator);
        }

        public void UpdatePopulation(int activeMatesCount)
        {
            activeMatesCount = population.Length; // TODO allow for variable number of active mates
            Chromosome[] parents = new Chromosome[activeMatesCount];
            Chromosome[] updatedPopulation = new Chromosome[population.Length];
            for(int i = 0; i < activeMatesCount; i++)
            {
                parents[i] = chromosomeSelector.SelectForMating(population);
            }

            for(int i = 0; i < activeMatesCount; i += 2)
            {
                var parent1 = parents[rand.Next(activeMatesCount)];
                var parent2 = parents[rand.Next(activeMatesCount)];

                var (offspring1, offspring2) = matingStrategy.ProduceOffspring(parent1, parent2);
                updatedPopulation[i] = offspring1;
                updatedPopulation[i + 1] = offspring2;
            }

            // TODO fill the remaining places in updated population (in some clever way)
            Array.Copy(updatedPopulation, population, population.Length);

            // TODO perform mutation
        }

        public void Run(int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                UpdatePopulation(population.Length);
            }
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
