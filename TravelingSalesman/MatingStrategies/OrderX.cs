using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.MatingStrategies
{
    public class OrderX : IMatingStrategy
    {
        private readonly Random rand;

        public OrderX(Random rand)
        {
            this.rand = rand;
        }

        public (Chromosome, Chromosome) ProduceOffspring(Chromosome parent1, Chromosome parent2)
        {
            int begin = rand.Next(parent1.Genomes.Length);
            int end = rand.Next(parent2.Genomes.Length);
            if (begin > end) (begin, end) = (end, begin);

            return CrossoverOperators.OX(parent1, parent2, begin, end - begin);
        }

        public Chromosome ProduceSingleOffspring(Chromosome parent1, Chromosome parent2)
        {
            int begin = rand.Next(parent1.Genomes.Length);
            int end = rand.Next(parent2.Genomes.Length);
            if (begin > end) (begin, end) = (end, begin);

            return CrossoverOperators.OXSingleOffspring(parent1, parent2, begin, end - begin);
        }

        public override string ToString()
        {
            return "order crossover";
        }
    }
}
