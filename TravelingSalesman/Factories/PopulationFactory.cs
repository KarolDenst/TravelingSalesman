using TravelingSalesman.Chromosomes;
using TravelingSalesman.Factories.Interfaces;

namespace TravelingSalesman.Factories
{
    public class PopulationFactory
    {
        private readonly IChromosomeFactory chromosomeFactory;
        public PopulationFactory(IChromosomeFactory chromosomeFactory)
        {
            this.chromosomeFactory = chromosomeFactory;
        }

        public Chromosome[] CreatePopulation(int populationSize, int chromosomeLength)
        {
            Chromosome[] population = new Chromosome[populationSize];

            for (int i = 0; i < populationSize; i++)
            {
                population[i] = chromosomeFactory.CreateRandomChromosome(chromosomeLength);
            }

            return population;
        }
    }
}
