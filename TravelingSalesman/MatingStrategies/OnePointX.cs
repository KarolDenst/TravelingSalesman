using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.MatingStrategies
{
    internal class OnePointX : IMatingStrategy
    {
        private readonly int[] canonicTour;

        private readonly Random rand;

        public OnePointX(int[] canonicTour, Random rand)
        {
            this.canonicTour = canonicTour;
            this.rand = rand;
        }
        public (Chromosome, Chromosome) ProduceOffspring(Chromosome parent1, Chromosome parent2)
        {
            int point = rand.Next(parent1.Genomes.Length);

            int[] parent1Ordinal = OrdinalRepresentaion.ToOrd((int[])parent1, canonicTour);
            int[] parent2Ordinal = OrdinalRepresentaion.ToOrd((int[])parent2, canonicTour);

            var (offspring1, offspring2) = CrossoverOperators.OnePoint(parent1Ordinal, parent2Ordinal, point);

            return (OrdinalRepresentaion.FromOrd((int[])offspring1, canonicTour),
                OrdinalRepresentaion.FromOrd((int[])offspring2, canonicTour));
        }

        public Chromosome ProduceSingleOffspring(Chromosome parent1, Chromosome parent2)
        {
            int point = rand.Next(parent1.Genomes.Length);

            int[] parent1Ordinal = OrdinalRepresentaion.ToOrd((int[])parent1, canonicTour);
            int[] parent2Ordinal = OrdinalRepresentaion.ToOrd((int[])parent2, canonicTour);

            var offspring = CrossoverOperators.OnePointSingleOffspring(parent1Ordinal, parent2Ordinal, point);

            return OrdinalRepresentaion.FromOrd((int[])offspring, canonicTour);
        }
    }
}
