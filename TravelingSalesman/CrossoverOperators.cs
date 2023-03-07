namespace TravelingSalesman
{
    public class CrossoverOperators
    {
        private static int[] PmxSingleOffspring(int[] p1, int[] p2, int begin, int length)
        {
            if (length == 0)
                return p1;

            int n = p1.Length;
            int[] offspring = new int[n];
            Array.Fill(offspring, -1);

            List<int> shadowed = new();
            List<int> shadowing = new();

            for (int i = begin; i < begin + length; i++)
            {
                offspring[i] = p1[i];
            }

            for (int i = begin; i < begin + length; i++)
            {
                if (!offspring.Contains(p2[i]))
                {
                    shadowed.Add(p2[i]);
                    shadowing.Add(p1[i]);
                }
            }

            for (int i = 0; i < shadowed.Count; i++)
            {
                int pos = Array.IndexOf(p2, shadowing[i]);
                if (offspring[pos] == -1)
                {
                    offspring[pos] = shadowed[i];
                }
                else
                {
                    int k = offspring[pos];
                    int posK = Array.IndexOf(p2, k);
                    offspring[posK] = shadowed[i];
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (offspring[i] == -1)
                    offspring[i] = p2[i];
            }

            return offspring;
        }

        public static (int[], int[]) PMX(int[] p1, int[] p2, int begin, int length)
        {
            return (PmxSingleOffspring(p1, p2, begin, length),
                PmxSingleOffspring(p2, p1, begin, length));
        }

        public static (int[], int[]) CX(int[] p1, int[] p2)
        {
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

            return (offspring1, offspring2);
        }

        public static (int[], int[]) OX(int[] p1, int[] p2, int begin, int length)
        {
            return (OxSingleOffspring(p1, p2, begin, length),
                OxSingleOffspring(p2, p1, begin, length));
        }

        private static int[] OxSingleOffspring(int[] p1, int[] p2, int begin, int length)
        {
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

            return Rotate(offspring, begin).ToArray();
        }

        private static List<int> Rotate(List<int> list, int offset)
        {
            return list.TakeLast(offset).Concat(list.SkipLast(offset)).ToList();
        }
    }
}
