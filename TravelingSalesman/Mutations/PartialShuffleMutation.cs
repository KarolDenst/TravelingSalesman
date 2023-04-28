using TravelingSalesman.Chromosomes;
using TravelingSalesman.Utils;

namespace TravelingSalesman.Mutations
{
    public class PartialShuffleMutation : IMutation
    {
        private readonly IArrayShuffler arrayShuffler;
        private readonly Random rand;

        public PartialShuffleMutation(IArrayShuffler arrayShuffler, Random rand)
        {
            this.arrayShuffler = arrayShuffler;
            this.rand = rand;
        }
        
        public Chromosome Mutate(Chromosome chromosome)
        {
            int[] genomes = chromosome.Genomes;

            int a = rand.Next(genomes.Length);
            int b = rand.Next(genomes.Length);

            if (a == b) return genomes;
            if (a > b) (a, b) = (b, a);

            int[] subArray;
            int[] shuffled;

            const int maxIt = 25;
            int i = 0;

            do
            {
                subArray = genomes.Skip(a).Take(b - a).ToArray();
                shuffled = arrayShuffler.Shuffle(subArray);
            } while (subArray.SequenceEqual(shuffled) && ++i < maxIt);

            if (i == maxIt) return genomes;
            
            int[] mutated = genomes
                .Take(a)
                .Concat(shuffled)
                .Concat(genomes.Skip(b))
                .ToArray();

            return mutated;
        }

        public override string ToString()
        {
            return "partial shuffle mutation";
        }
    }
}
