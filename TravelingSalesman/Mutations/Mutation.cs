using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.Mutations
{
    public abstract class Mutation
    {
        public abstract Chromosome Mutate(Chromosome chromosome);

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
