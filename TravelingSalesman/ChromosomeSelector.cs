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

        private double[] GetChances(Chromosome[] population)
        {
            double fitnessSum = 0;
            foreach (var chromosome in population)
            {
                fitnessSum += fitnessCalculator.CalculateFitness(chromosome);
            }
            double[] chance = new double[population.Length];

            for (int i = 0; i < population.Length; i++)
            {
                chance[i] = fitnessCalculator.CalculateFitness(population[i]) / fitnessSum;
            }
            chance[^1] = 1;

            return chance;
        }

        public Chromosome DrawRandomChromosome(Chromosome[] population)
        {
            double[] chance = GetChances(population);
            for (int i = 0; i < population.Length; i++)
            {
                if (rand.NextDouble() < chance[i]) return population[i];
            }

            return population[^1];
        }
    }
}
