using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.MatingStrategies
{
    public class OrderX2 : IMatingStrategy
    {
        private readonly Random rand;

        public OrderX2(Random rand)
        {
            this.rand = rand;
        }

        public (Chromosome, Chromosome) ProduceOffspring(Chromosome parent1, Chromosome parent2)
        {
            throw new NotImplementedException();
        }

        public Chromosome ProduceSingleOffspring(Chromosome parent1, Chromosome parent2)
        {
            int start = rand.Next(parent1.Genomes.Length);
            int end = rand.Next(parent1.Genomes.Length);
            if (start > end) (start, end) = (end, start);

            return CrossoverOperators.OX2SingleOffspring(parent1, parent2, start, end - start);
        }

        public override string ToString()
        {
            return "order crossover (v2)";
        }
    }
}
