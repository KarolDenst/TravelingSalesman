using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.Interfaces
{
    public interface IData
    {
        public double GetFitness(Chromosome chromosome);
    }
}
