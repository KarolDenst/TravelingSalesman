using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.Mutations
{
    public interface IMutation
    {
        Chromosome Mutate(Chromosome chromosome);
    }
}
