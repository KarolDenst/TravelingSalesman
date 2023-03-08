using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.Mutations
{
    public class ThrorosMutation : IMutation
    {
        private readonly Random rand;

        public ThrorosMutation(Random rand)
        {
            this.rand = rand;
        }

        public Chromosome Mutate(Chromosome chromosome)
        {
            int[] genomes = chromosome.Genomes;
            int[] mutated = new int[chromosome.Genomes.Length];
            Array.Copy(genomes, mutated, mutated.Length);

            int[] positions = new int[mutated.Length].Select((_, index) => index).ToArray();
            rand.Shuffle(positions);
            int[] ps = positions.Take(3).Order().ToArray();

            mutated[ps[0]] = genomes[ps[2]];
            mutated[ps[2]] = genomes[ps[1]];
            mutated[ps[1]] = genomes[ps[0]];

            return mutated;
        }
    }
}
