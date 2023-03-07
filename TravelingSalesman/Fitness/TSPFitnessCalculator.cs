using TravelingSalesman.Chromosomes;
using TravelingSalesman.Data;

namespace TravelingSalesman.TSPFitness
{
    internal class TSPFitnessCalculator : IFitnessCalculator
    {
        public Graph UnderlyingGraph { get; }
        public TSPFitnessCalculator(Graph underlyingGraph)
        {
            UnderlyingGraph = underlyingGraph;
        }

        public double CalculateFitness(Chromosome chromosome)
        {
            return 1.0 / UnderlyingGraph.GetCycleLength(chromosome.Genomes);
        }
    }
}
