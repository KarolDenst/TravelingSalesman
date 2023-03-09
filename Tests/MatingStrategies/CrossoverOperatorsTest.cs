using TravelingSalesman.MatingStrategies;

namespace Tests.MatingStrategies
{
    public class CrossoverOperatorsTests
    {
        public static IEnumerable<object[]> TestDataPmx()
        {
            yield return new object[] {
                new int[] { 1, 3, 5, 6, 4, 2, 7, 8 },
                new int[] { 1, 5, 2, 3, 6, 4, 8, 7 },
                new int[] { 1, 2, 5, 6, 4, 3, 8, 7 },
                new int[] { 1, 4, 2, 3, 6, 5, 7, 8 },
                2, 2 };

            yield return new object[] {
                new int[] { 9, 3, 2, 4, 5, 6, 7, 1, 8 },
                new int[] { 1, 7, 3, 8, 2, 6, 5, 4, 9 },
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new int[] { 9, 3, 7, 8, 2, 6, 5, 1, 4 },
                3, 3 };

            yield return new object[] {
                new int[] { 4, 8, 5, 2, 7, 1, 3, 6 },
                new int[] { 3, 4, 2, 1, 6, 8, 7, 5 },
                new int[] { 3, 4, 8, 2, 7, 1, 6, 5 },
                new int[] { 4, 2, 5, 1, 6, 8, 3, 7 },
                3, 2 };
        }

        public static IEnumerable<object[]> TestDataCx()
        {
            yield return new object[] {
                new int[] { 1, 5, 2, 4, 3, 6, 7, 8 },
                new int[] { 8, 2, 3, 1, 5, 6, 4, 7 },
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8 },
                new int[] { 8, 5, 2, 1, 3, 6, 4, 7 }
            };

            yield return new object[] {
                new int[] { 3, 4, 8, 2, 7, 1, 6, 5 },
                new int[] { 4, 2, 5, 1, 6, 8, 3, 7 },
                new int[] { 3, 4, 8, 2, 7, 1, 6, 5 },
                new int[] { 4, 2, 5, 1, 6, 8, 3, 7 },
            };
        }
        public static IEnumerable<object[]> TestDataOx()
        {
            yield return new object[] {
                new int[] { 0, 4, 7, 3, 6, 2, 5, 1, 8, 9 },
                new int[] { 8, 2, 1, 3, 4, 5, 6, 7, 9, 0 },
                new int[] { 8, 4, 7, 3, 6, 2, 5, 1, 9, 0 },
                new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                3, 5};
        }


        [Theory]
        [MemberData(nameof(TestDataPmx))]
        public void TestPMX(int[] expected1, int[] expected2, int[] p1, int[] p2, int begin, int length)
        {
            var (offspring1, offspring2) = CrossoverOperators.PMX(p1, p2, begin, length);

            Assert.Equal(expected1, offspring1.Genomes);
            Assert.Equal(expected2, offspring2.Genomes);
        }

        [Theory]
        [MemberData(nameof(TestDataCx))]
        public void TestCx(int[] expected1, int[] expected2, int[] p1, int[] p2)
        {
            var (offspring1, offspring2) = CrossoverOperators.CX(p1, p2);

            Assert.Equal(expected1, offspring1.Genomes);
            Assert.Equal(expected2, offspring2.Genomes);
        }

        [Theory]
        [MemberData(nameof(TestDataOx))]
        public void TestOx(int[] expected1, int[] expected2, int[] p1, int[] p2, int begin, int length)
        {
            var (offspring1, offspring2) = CrossoverOperators.OX(p1, p2, begin, length);

            Assert.Equal(expected1, offspring1.Genomes);
            Assert.Equal(expected2, offspring2.Genomes);
        }
    }
}