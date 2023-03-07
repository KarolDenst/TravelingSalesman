using System.Text;
using TravelingSalesman.Interfaces;

namespace TravelingSalesman
{
    public class TSPChromosome : IChromosome
    {
        static IData Data;
        static readonly Random Rand = new Random();

        public int[] Genomes { get; set; }
        public double Fitness { get; set; }
        private int PathLength;

        public TSPChromosome() { }

        public TSPChromosome(int[] genomes)
        {
            Genomes = genomes;
            PathLength = (int)Data.GetFitness(this);
            Fitness = 1.0 / PathLength;
        }

        public IChromosome CreateChild(IChromosome second)
        {
            int start = Rand.Next(Genomes.Length);
            int end = Rand.Next(Genomes.Length);
            if (start > end) (start, end) = (end, start);
            List<int> subset = Genomes.ToList().GetRange(start, end - start);

            var child = second.Genomes.Where(x => !subset.Contains(x)).ToList();
            child.InsertRange(start, subset);
            return new TSPChromosome(child.ToArray());
        }

        public static void SetData(IData cityGraph)
        {
            Data = cityGraph;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Fitness: " + PathLength + " Genomes: ");
            foreach (int genome in Genomes)
            {
                sb.Append(genome.ToString() + " ");
            }

            return sb.ToString();
        }
    }
}
