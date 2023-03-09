using System.Text;
using TravelingSalesman.Factories.Interfaces;
using TravelingSalesman.Interfaces;

namespace TravelingSalesman
{
    internal class EvolutionaryAlgo
    {
        static readonly Random Rand = new Random();
        readonly IChromosomeFactory Factory;
        public IChromosome[] Population;

        public EvolutionaryAlgo(int ChromosomeLength, int populationSize, IChromosomeFactory factory)
        {
            Factory = factory;
            Population = CreatePopulation(populationSize, ChromosomeLength);
        }

        private IChromosome[] CreatePopulation(int populationSize, int chromosomeLength)
        {
            IChromosome[] population = new IChromosome[populationSize];

            for (int i = 0; i < populationSize; i++)
            {
                population[i] = Factory.CreateRandomChromosome(chromosomeLength);
            }

            return population;
        }

        private double[] GetChances()
        {
            double fitnessSum = 0;
            foreach (var chromosome in Population)
            {
                fitnessSum += chromosome.Fitness;
            }
            double[] chance = new double[Population.Length];

            for (int i = 0; i < Population.Length; i++)
            {
                chance[i] = Population[i].Fitness / fitnessSum;
            }
            chance[^1] = 1;

            return chance;
        }

        private IChromosome DrawRandomChromosome(double[] chance)
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
            IChromosome[] newPopulation = new IChromosome[Population.Length];

            for (int i = 0; i < newPopulation.Length; i++)
            {
                IChromosome first = DrawRandomChromosome(chance);
                IChromosome second = DrawRandomChromosome(chance);

                newPopulation[i] = first.CreateChild(second);
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
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Population.Length; i++)
            {
                sb.Append($"{i.ToString()} - {Population[i].ToString()} {Environment.NewLine}");
            }

            return sb.ToString();
        }
    }
}
