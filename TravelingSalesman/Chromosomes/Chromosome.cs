using System.Text;

namespace TravelingSalesman.Chromosomes
{
    public class Chromosome
    {
        public int[] Genomes { get; }

        public Chromosome(int[] genomes)
        {
            Genomes = genomes;
        }

        public static explicit operator int[](Chromosome c) => c.Genomes;

        public static implicit operator Chromosome(int[] genomes) => new Chromosome(genomes);

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append("Genomes: <");
            foreach (int genome in Genomes)
            {
                sb.Append(genome.ToString() + " ");
            }
            sb.Append(">");

            return sb.ToString();
        }
    }
}
