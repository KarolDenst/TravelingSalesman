using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.Mutations
{
    public class TworsMutation : IMutation
    {
        private readonly Random rand;

        public TworsMutation(Random rand)
        {
            this.rand = rand;
        }

        public Chromosome Mutate(Chromosome chromosome)
        {
            int[] mutated = new int[chromosome.Genomes.Length];
            Array.Copy(chromosome.Genomes, mutated, mutated.Length);

            int pos1 = rand.Next(mutated.Length);
            int pos2 = rand.Next(mutated.Length);

            (mutated[pos1], mutated[pos2]) = (mutated[pos2], mutated[pos1]);

            return mutated;
        }

        public override string ToString()
        {
            return "TWORS mutation";
        }
    }
}
