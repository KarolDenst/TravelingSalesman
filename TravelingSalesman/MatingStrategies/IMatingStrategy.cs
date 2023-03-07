using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.MatingStrategies
{
    internal interface IMatingStrategy
    {
        (Chromosome, Chromosome) ProduceOffspring(Chromosome parent1, Chromosome parent2);
        Chromosome ProduceSingleOffspring(Chromosome parent1, Chromosome parent2);
    }
}
