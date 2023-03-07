using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.Data
{
    public interface IData
    {
        public double GetFitness(Chromosome chromosome);
    }
}
