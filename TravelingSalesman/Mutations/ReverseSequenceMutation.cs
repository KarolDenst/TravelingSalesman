using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.Mutations
{
    public class ReverseSequenceMutation : IMutation
    {
        private readonly Random rand;

        public ReverseSequenceMutation(Random rand)
        {
            this.rand = rand;
        }

        public Chromosome Mutate(Chromosome chromosome)
        {
            int[] genomes = chromosome.Genomes;

            int a = rand.Next(genomes.Length);
            int b = rand.Next(genomes.Length);

            if (a > b) (a, b) = (b, a);

            int[] mutated = new int[chromosome.Genomes.Length];
            Array.Copy(chromosome.Genomes, mutated, mutated.Length);

            while (a <= b)
            {
                (mutated[a], mutated[b]) = (mutated[b], mutated[a]);
                a++;
                b--;
            }

            return mutated;
        }

        public override string ToString()
        {
            return "reverse sequence mutation";
        }
    }
}
