using System.Text;
using TravelingSalesman.Chromosomes;
using TravelingSalesman.Factories;
using TravelingSalesman.Factories.Interfaces;
using TravelingSalesman.MatingStrategies;
using TravelingSalesman.TSPFitness;

namespace TravelingSalesman.Algorithms
{
    internal class EvolutionaryAlgo
    {
        static readonly Random Rand = new();
        readonly IMatingStrategy matingStrategy;
        readonly TSPFitnessCalculator fitnessCalculator;
        public Chromosome[] Population;
        readonly PopulationFactory populationFactory;

        public EvolutionaryAlgo(int ChromosomeLength, int populationSize,
            IChromosomeFactory factory, IMatingStrategy matingStrategy,
            TSPFitnessCalculator fitnessCalculator)
        {
            populationFactory = new(factory);
            Population = populationFactory.CreatePopulation(populationSize, ChromosomeLength);
            this.matingStrategy = matingStrategy;
            this.fitnessCalculator = fitnessCalculator;
            populationFactory = new(factory);
        }

        private double[] GetChances()
        {
            double fitnessSum = 0;
            foreach (var chromosome in Population)
            {
                fitnessSum += fitnessCalculator.CalculateFitness(chromosome);
            }
            double[] chance = new double[Population.Length];

            for (int i = 0; i < Population.Length; i++)
            {
                chance[i] = fitnessCalculator.CalculateFitness(Population[i]);
            }
            chance[^1] = 1;

            return chance;
        }

        private Chromosome DrawRandomChromosome(double[] chance)
        {
            for (int i = 0; i < Population.Length; i++)
            {
                if (Rand.NextDouble() < chance[i]) return Population[i];
            }

            return Population[^1];
        }

        public void UpdatePopulation()
        {
            double[] chance = GetChances();
            Chromosome[] newPopulation = new Chromosome[Population.Length];

            for (int i = 0; i < newPopulation.Length; i++)
            {
                Chromosome first = DrawRandomChromosome(chance);
                Chromosome second = DrawRandomChromosome(chance);

                newPopulation[i] = matingStrategy.ProduceSingleOffspring(first, second);
            }
        }

        public void Run(int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                UpdatePopulation();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            for (int i = 0; i < Population.Length; i++)
            {
                sb.Append($"{i.ToString()} - {Population[i].ToString()}");
                double cycleLength = fitnessCalculator.UnderlyingGraph.GetCycleLength(Population[i].Genomes);
                sb.Append($" (path length = {cycleLength})\n");
            }

            return sb.ToString();
        }
    }
}
