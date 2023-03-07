using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.MatingStrategies
{
    internal class OnePointX : IMatingStrategy
    {
        public (Chromosome, Chromosome) ProduceOffspring(Chromosome parent1, Chromosome parent2)
        {
            Random rand = new();
            int point = rand.Next(parent1.Genomes.Length);

            return CrossoverOperators.OnePoint(parent1, parent2, point);
        }

        public Chromosome ProduceSingleOffspring(Chromosome parent1, Chromosome parent2)
        {
            Random rand = new();
            int point = rand.Next(parent1.Genomes.Length);

            return CrossoverOperators.OnePointSingleOffspring(parent1, parent2, point);
        }
    }
}
