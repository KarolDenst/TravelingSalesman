using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.Mutations
{
    internal class UselessMutation : IMutation
    {
        public Chromosome Mutate(Chromosome chromosome)
        {
            return chromosome;
        }

        public override string ToString()
        {
            return "no mutation";
        }
    }
}
