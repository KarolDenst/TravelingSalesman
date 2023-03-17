using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.Mutations
{
    internal class UselessMutation : IMutation
    {
        public Chromosome Mutate(Chromosome chromosome)
        {
            return chromosome;
        }
    }
}
