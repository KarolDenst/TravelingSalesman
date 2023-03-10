using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.TSPFitness
{
    public interface IFitnessCalculator
    {
        double CalculateFitness(Chromosome chromosome);
    }
}
