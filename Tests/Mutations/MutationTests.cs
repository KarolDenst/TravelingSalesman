using Moq;
using TravelingSalesman.Mutations;
using TravelingSalesman.Utils;

namespace Tests.Mutations
{
    public class MutationTests
    {

        public static IEnumerable<object[]> TestDataCIM()
        {
            yield return new object[]
            {
                new int[] { 4, 3, 2, 1, 6, 5 },
                new int[] { 1, 2, 3, 4, 5, 6 },
                4
            };
        }

        public static IEnumerable<object[]> TestDataRSM()
        {
            yield return new object[]
            {
                new int[] { 1, 5, 4, 3, 2, 6 },
                new int[] { 1, 2, 3, 4, 5, 6 },
                1, 4
            };
        }

        public static IEnumerable<object[]> TestDataThoras()
        {
            yield return new object[]
            {
                new int[] { 1, 4, 2, 3, 5, 6 },
                new int[] { 1, 2, 3, 4, 5, 6 },
                1
            };
        }

        public static IEnumerable<object[]> TestDataThoros()
        {
            yield return new object[]
            {
                new int[] { 1, 6, 3, 2, 5, 4 },
                new int[] { 1, 2, 3, 4, 5, 6 },
                Enumerable.Range(0, 6).ToArray(),
                new int[] { 1, 3, 5, 2, 4, 6 },
            };
        }

        public static IEnumerable<object[]> TestDataTwors()
        {
            yield return new object[]
            {
                new int[] { 1, 2, 3, 6, 5, 4 },
                new int[] { 1, 2, 3, 4, 5, 6 },
                3, 5
            };
        }

        [Theory]
        [MemberData(nameof(TestDataCIM))]
        public void TestCenterInverseMutation(int[] expected, int[] chromosome, int split)
        {
            Mock<Random> mockRandom = new Mock<Random>();
            mockRandom.Setup(rand => rand.Next(chromosome.Length)).Returns(split);

            var subject = new CenterInverseMutation(mockRandom.Object);

            var actual = subject.Mutate(chromosome);
            Assert.Equal(expected, actual.Genomes);
        }

        [Theory]
        [MemberData(nameof(TestDataRSM))]
        public void TestReverseSequenceMutation(int[] expected, int[] chromosome, int i, int j)
        {
            Mock<Random> mockRandom = new Mock<Random>();
            mockRandom.SetupSequence(rand => rand.Next(chromosome.Length))
                .Returns(i)
                .Returns(j);

            var subject = new ReverseSequenceMutation(mockRandom.Object);

            var actual = subject.Mutate(chromosome);
            Assert.Equal(expected, actual.Genomes);
        }

        [Theory]
        [MemberData(nameof(TestDataThoras))]
        public void TestThorasMutation(int[] expected, int[] chromosome, int p1)
        {
            Mock<Random> mockRandom = new Mock<Random>();
            mockRandom.Setup(rand => rand.Next(chromosome.Length - 2)).Returns(p1);

            var subject = new ThorasMutation(mockRandom.Object);

            var actual = subject.Mutate(chromosome);
            Assert.Equal(expected, actual.Genomes);
        }

        [Theory]
        [MemberData(nameof(TestDataThoros))]
        public void TestThorosMutation(int[] expected, int[] chromosome, int[] range, int[] shuffledRange)
        {
            Mock<IArrayShuffler> mockArrayShuffler = new Mock<IArrayShuffler>();
            mockArrayShuffler.Setup(shuffler => shuffler.Shuffle(range))
                .Returns(shuffledRange);

            var subject = new ThorosMutation(mockArrayShuffler.Object);

            var actual = subject.Mutate(chromosome);
            Assert.Equal(expected, actual.Genomes);
        }

        [Theory]
        [MemberData(nameof(TestDataTwors))]
        public void TestTworsMutation(int[] expected, int[] chromosome, int p1, int p2)
        {
            Mock<Random> mockRandom = new Mock<Random>();
            mockRandom.SetupSequence(rand => rand.Next(chromosome.Length))
                .Returns(p1)
                .Returns(p2);

            var subject = new TworsMutation(mockRandom.Object);

            var actual = subject.Mutate(chromosome);
            Assert.Equal(expected, actual.Genomes);
        }
    }
}
