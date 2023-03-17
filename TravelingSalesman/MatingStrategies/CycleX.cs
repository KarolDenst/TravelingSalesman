using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.MatingStrategies
{
    public class CycleX : MatingStrategy
    {
        public override (Chromosome, Chromosome) ProduceOffspring(Chromosome parent1, Chromosome parent2)
        {
            return CrossoverOperators.CX(parent1, parent2);
        }

        public override Chromosome ProduceSingleOffspring(Chromosome parent1, Chromosome parent2)
        {
            return CrossoverOperators.CXSingleOffspring(parent1, parent2);
        }
    }
}
