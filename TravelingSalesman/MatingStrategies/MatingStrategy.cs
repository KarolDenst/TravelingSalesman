using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.MatingStrategies
{
    public abstract class MatingStrategy
    {
        public abstract (Chromosome, Chromosome) ProduceOffspring(Chromosome parent1, Chromosome parent2);
        public abstract Chromosome ProduceSingleOffspring(Chromosome parent1, Chromosome parent2);

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
