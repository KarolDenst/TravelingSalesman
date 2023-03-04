using TravelingSalesman.Interfaces;

namespace TravelingSalesman.Factories.Interfaces
{
    internal interface IChromosomeFactory
    {
        public IChromosome CreateRandomChromosome(int length);
    }
}
