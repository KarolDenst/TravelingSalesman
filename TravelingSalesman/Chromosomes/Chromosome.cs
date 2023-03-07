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

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append(" Genomes: ");
            foreach (int genome in Genomes)
            {
                sb.Append(genome.ToString() + " ");
            }

            return sb.ToString();
        }
    }
}
