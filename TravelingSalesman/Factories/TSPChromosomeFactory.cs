using TravelingSalesman.Chromosomes;
using TravelingSalesman.Factories.Interfaces;
using TravelingSalesman.Interfaces;

namespace TravelingSalesman.Factories
{
    internal class TSPChromosomeFactory : IChromosomeFactory
    {
        private readonly Random rand;

        public TSPChromosomeFactory(Random rand)
        {
            this.rand = rand;
        }

        public Chromosome CreateRandomChromosome(int length)
        {
            int[] chromosome = new int[length];
            for (int i = 0; i < length; i++)
            {
                chromosome[i] = i;
            }

            return new Chromosome(chromosome.OrderBy(x => rand.NextDouble()).ToArray());
        }
    }
}
