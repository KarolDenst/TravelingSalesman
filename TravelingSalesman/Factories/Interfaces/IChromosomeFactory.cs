using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.Factories.Interfaces
{
    public interface IChromosomeFactory
    {
        public Chromosome CreateRandomChromosome(int length);
    }
}
