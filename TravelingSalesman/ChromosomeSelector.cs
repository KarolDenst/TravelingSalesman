using TravelingSalesman.Chromosomes;
using TravelingSalesman.TSPFitness;

namespace TravelingSalesman
{
    public class ChromosomeSelector
    {
        static readonly Random rand = new();
        private readonly IFitnessCalculator fitnessCalculator;
        public ChromosomeSelector(IFitnessCalculator fitnessCalculator)
        {
            this.fitnessCalculator = fitnessCalculator;
        }

        public Chromosome SelectForMating(Chromosome[] chromosomes)
        {
            var fitnessSum = chromosomes.Sum(fitnessCalculator.CalculateFitness);
            double r = rand.NextDouble() * fitnessSum;

            double currentSum = 0;
            foreach (var c in chromosomes)
            {
                currentSum += fitnessCalculator.CalculateFitness(c);
                if (currentSum >= r)
                    return c;
            }

            return chromosomes[^1];
        }
    }
}
