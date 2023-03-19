using TravelingSalesman.Chromosomes;
using TravelingSalesman.Utils;

namespace TravelingSalesman.Mutations
{
    public class ThorosMutation : IMutation
    {
        private readonly IArrayShuffler arrayShufler;

        public ThorosMutation(IArrayShuffler arrayShufler)
        {
            this.arrayShufler = arrayShufler;
        }

        public Chromosome Mutate(Chromosome chromosome)
        {
            int[] genomes = chromosome.Genomes;
            int[] mutated = new int[chromosome.Genomes.Length];
            Array.Copy(genomes, mutated, mutated.Length);

            int[] positions = Enumerable.Range(0, mutated.Length).ToArray();
            //int[] ps = rand.Shuffle(positions).Take(3).Order().ToArray();
            int[] ps = arrayShufler.Shuffle(positions).Take(3).Order().ToArray();

            mutated[ps[0]] = genomes[ps[2]];
            mutated[ps[2]] = genomes[ps[1]];
            mutated[ps[1]] = genomes[ps[0]];

            return mutated;
        }

        public override string ToString()
        {
            return "THOROS mutation";
        }
    }
}
