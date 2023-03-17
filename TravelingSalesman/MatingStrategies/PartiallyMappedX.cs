using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.MatingStrategies
{
    public class PartiallyMappedX : MatingStrategy
    {
        private readonly Random rand;

        public PartiallyMappedX(Random rand)
        {
            this.rand = rand;
        }

        public override (Chromosome, Chromosome) ProduceOffspring(Chromosome parent1, Chromosome parent2)
        {
            int begin = rand.Next(parent1.Genomes.Length);
            int end = rand.Next(parent2.Genomes.Length);
            if (begin > end) (begin, end) = (end, begin);

            return CrossoverOperators.PMX(parent1, parent2, begin, end - begin);
        }

        public override Chromosome ProduceSingleOffspring(Chromosome parent1, Chromosome parent2)
        {
            int begin = rand.Next(parent1.Genomes.Length);
            int end = rand.Next(parent2.Genomes.Length);
            if (begin > end) (begin, end) = (end, begin);

            return CrossoverOperators.PMXSingleOffspring(parent1, parent2, begin, end - begin);
        }
    }
}
