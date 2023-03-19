using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.Mutations
{
    public class ThorasMutation : IMutation
    {
        private readonly Random rand;

        public ThorasMutation(Random rand)
        {
            this.rand = rand;
        }

        public Chromosome Mutate(Chromosome chromosome)
        {
            int[] genomes = chromosome.Genomes;
            int[] mutated = new int[chromosome.Genomes.Length];
            Array.Copy(genomes, mutated, mutated.Length);

            int p1 = rand.Next(genomes.Length - 2);
            int p2 = p1 + 1;
            int p3 = p1 + 2;

            mutated[p1] = genomes[p3];
            mutated[p3] = genomes[p2];
            mutated[p2] = genomes[p1];

            return mutated;
        }

        public override string ToString()
        {
            return "THORAS mutation";
        }
    }
}
