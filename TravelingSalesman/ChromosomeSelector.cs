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

        private double[] GetChances(Chromosome[] population)
        {
            double fitnessSum = population.Sum(fitnessCalculator.CalculateFitness);

            double[] chances = new double[population.Length];
            double prevProbability = 0;

            for (int i = 0; i < population.Length; i++)
            {
                chances[i] = prevProbability + fitnessCalculator.CalculateFitness(population[i]) / fitnessSum;
                prevProbability = chances[i];
            }

            return chances;
        }

        public Chromosome SelectForMating(Chromosome[] population)
        {
            double[] chances = GetChances(population);
            double r = rand.NextDouble();

            for (int i = 0; i < population.Length; i++)
            {
                if (r < chances[i]) 
                    return population[i];
            }

            return population[^1];
        }
    }
}
