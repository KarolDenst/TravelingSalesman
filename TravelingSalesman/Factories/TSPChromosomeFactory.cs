using TravelingSalesman.Factories.Interfaces;
using TravelingSalesman.Interfaces;

namespace TravelingSalesman.Factories
{
    internal class TSPChromosomeFactory : IChromosomeFactory
    {
        static readonly Random Rand = new Random();

        public IChromosome CreateRandomChromosome(int length)
        {
            int[] chromosome = new int[length];
            for (int i = 0; i < length; i++)
            {
                chromosome[i] = i;
            }

            return new TSPChromosome(chromosome.OrderBy(x => Rand.NextDouble()).ToArray());
        }
    }
}
