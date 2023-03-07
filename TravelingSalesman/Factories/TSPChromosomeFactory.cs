using TravelingSalesman.Chromosomes;
using TravelingSalesman.Factories.Interfaces;

namespace TravelingSalesman.Factories
{
    internal class TSPChromosomeFactory : IChromosomeFactory
    {
        static readonly Random Rand = new Random();

        public Chromosome CreateRandomChromosome(int length)
        {
            int[] chromosome = new int[length];
            for (int i = 0; i < length; i++)
            {
                chromosome[i] = i;
            }

            return new Chromosome(chromosome.OrderBy(x => Rand.NextDouble()).ToArray());
        }
    }
}
