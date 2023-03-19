using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.MatingStrategies
{
    internal class CycleX : IMatingStrategy
    {
        public (Chromosome, Chromosome) ProduceOffspring(Chromosome parent1, Chromosome parent2)
        {
            return CrossoverOperators.CX(parent1, parent2);
        }

        public Chromosome ProduceSingleOffspring(Chromosome parent1, Chromosome parent2)
        {
            return CrossoverOperators.CXSingleOffspring(parent1, parent2);
        }

        public override string ToString()
        {
            return "cycle crossover";
        }
    }
}
