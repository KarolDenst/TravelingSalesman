using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.MatingStrategies
{
    public class CrossoverOperators
    {
        public static Chromosome PMXSingleOffspring(Chromosome parent1, Chromosome parent2, int begin, int length)
        {
            int[] p1 = parent1.Genomes;
            int[] p2 = parent2.Genomes;
            int n = p1.Length;

            int[] offspring = new int[n];
            Array.Fill(offspring, -1);

            for (int i = begin; i <= begin + length; i++)
            {
                offspring[i] = p1[i];
            }

            for (int i = begin; i <= begin + length; i++)
            {
                int value = p2[i];

                if (Array.IndexOf(offspring, value) == -1)
                {
                    int j = i;

                    while (offspring[j] != -1)
                    {
                        j = Array.IndexOf(p2, offspring[j]);
                    }

                    offspring[j] = value;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (i >= begin && i <= begin + length)
                    continue;

                int value = p2[i];
                if (Array.IndexOf(offspring, value) == -1)
                {
                    int j = i;
                    while (offspring[j] != -1)
                    {
                        j = Array.IndexOf(p2, offspring[j]);
                    }
                    offspring[j] = value;
                }
            }

            return new Chromosome(offspring);
        }

        public static Chromosome CXSingleOffspring(Chromosome parent1, Chromosome parent2)
        {
            return CX(parent1, parent2).Item1;
        }

        public static Chromosome OXSingleOffspring(Chromosome parent1, Chromosome parent2, int begin, int length)
        {
            int[] p1 = parent1.Genomes;
            int[] p2 = parent2.Genomes;

            int size = p1.Length;
            List<int> offspring = p1.Skip(begin).Take(length).ToList();

            for (int i = 0; i < size; i++)
            {
                int currentCityIndex = (begin + length + i) % size;
                int currentCityInTour2 = p2[currentCityIndex];

                if (!offspring.Contains(currentCityInTour2))
                {
                    offspring.Add(currentCityInTour2);
                }
            }

            return new Chromosome(Rotate(offspring, begin).ToArray());
        }

        public static Chromosome OnePointSingleOffspring(Chromosome parent1, Chromosome parent2, int point)
        {
            return OnePoint(parent1, parent2, point).Item1;
        }

        // original implementation by K.D.
        public static Chromosome OX2SingleOffspring(Chromosome parent1, Chromosome parent2, int begin, int length)
        {
            List<int> subset = parent1.Genomes.ToList().GetRange(begin, length);

            var child = parent2.Genomes.Where(x => !subset.Contains(x)).ToList();
            child.InsertRange(begin, subset);
            return new Chromosome(child.ToArray());
        }

        public static (Chromosome, Chromosome) PMX(Chromosome p1, Chromosome p2, int begin, int length)
        {
            return (PMXSingleOffspring(p1, p2, begin, length),
                PMXSingleOffspring(p2, p1, begin, length));
        }

        public static (Chromosome, Chromosome) CX(Chromosome parent1, Chromosome parent2)
        {
            int[] p1 = parent1.Genomes;
            int[] p2 = parent2.Genomes;

            int n = p1.Length;
            int[] cycleIds = new int[n];
            Array.Fill(cycleIds, -1);

            int cycleStart;
            int curCycleId = 0;
            while ((cycleStart = Array.IndexOf(cycleIds, -1)) != -1)
            {
                int cur = cycleStart;
                do
                {
                    cycleIds[cur] = curCycleId;
                    cur = Array.IndexOf(p1, p2[cur]);
                } while (p1[cur] != p1[cycleStart]);

                curCycleId++;
            }

            int[] offspring1 = new int[n];
            int[] offspring2 = new int[n];

            for (int i = 0; i < n; i++)
            {
                if (cycleIds[i] % 2 == 0)
                {
                    offspring1[i] = p1[i];
                    offspring2[i] = p2[i];
                }
                else
                {
                    offspring2[i] = p1[i];
                    offspring1[i] = p2[i];
                }
            }

            return (new Chromosome(offspring1),
                new Chromosome(offspring2));
        }

        public static (Chromosome, Chromosome) OX(Chromosome parent1, Chromosome parent2, int begin, int length)
        {
            return (OXSingleOffspring(parent1, parent2, begin, length),
                OXSingleOffspring(parent2, parent1, begin, length));
        }

        public static (Chromosome, Chromosome) OnePoint(Chromosome parent1, Chromosome parent2, int point)
        {
            int[] p1 = parent1.Genomes;
            int[] p2 = parent2.Genomes;

            int[] offspring1 = p1.Take(point).Concat(p2.Skip(point)).ToArray();
            int[] offspring2 = p2.Take(point).Concat(p1.Skip(point)).ToArray();

            return (new Chromosome(offspring1), new Chromosome(offspring2));
        }

        private static List<int> Rotate(List<int> list, int offset)
        {
            return list.TakeLast(offset).Concat(list.SkipLast(offset)).ToList();
        }
    }
}