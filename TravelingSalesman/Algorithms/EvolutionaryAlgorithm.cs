using TravelingSalesman.Factories.Interfaces;
using TravelingSalesman.MatingStrategies;
using TravelingSalesman.Mutations;
using TravelingSalesman.TSPFitness;

namespace TravelingSalesman.Algorithms
{
    internal class EvolutionaryAlgorithm : GeneticAlgorithm
    {
        public EvolutionaryAlgorithm(int chromosomeLength, int populationSize, IChromosomeFactory factory,
            IMatingStrategy matingStrategy, TSPFitnessCalculator fitnessCalculator, Random rand)
            : base(chromosomeLength, populationSize, factory,
                  matingStrategy, new UselessMutation(), fitnessCalculator, rand)
        {
        }
    }
}
