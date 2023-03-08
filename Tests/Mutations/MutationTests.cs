using Moq;
using TravelingSalesman.Chromosomes;
using TravelingSalesman.Mutations;
using TravelingSalesman.Utils;

namespace Tests.Mutations
{
    public class MutationTests
    {
        [Fact]
        public void TestCenterInverseMutation()
        {
            Chromosome chromosome = new(new int[] { 1, 2, 3, 4, 5, 6 });
            Mock<Random> mockRandom = new Mock<Random>();
            mockRandom.Setup(rand => rand.Next(chromosome.Genomes.Length)).Returns(4);

            var subject = new CenterInverseMutation(mockRandom.Object);
            int[] expected = new int[] { 4, 3, 2, 1, 6, 5 };

            var actual = subject.Mutate(chromosome);
            Assert.Equal(expected, actual.Genomes);
        }

        [Fact]
        public void TestReverseSequenceMutation()
        {
            Chromosome chromosome = new(new int[] { 1, 2, 3, 4, 5, 6 });
            Mock<Random> mockRandom = new Mock<Random>();
            mockRandom.SetupSequence(rand => rand.Next(chromosome.Genomes.Length))
                .Returns(1)
                .Returns(4);

            var subject = new ReverseSequenceMutation(mockRandom.Object);
            int[] expected = new int[] { 1, 5, 4, 3, 2, 6 };

            var actual = subject.Mutate(chromosome);
            Assert.Equal(expected, actual.Genomes);
        }

        [Fact]
        public void TestThorasMutation()
        {
            Chromosome chromosome = new(new int[] { 1, 2, 3, 4, 5, 6 });
            Mock<Random> mockRandom = new Mock<Random>();
            mockRandom.Setup(rand => rand.Next(chromosome.Genomes.Length - 2)).Returns(1);

            var subject = new ThorasMutation(mockRandom.Object);
            int[] expected = new int[] { 1, 4, 2, 3, 5, 6 };

            var actual = subject.Mutate(chromosome);
            Assert.Equal(expected, actual.Genomes);
        }

        [Fact]
        public void TestThorosMutation()
        {
            Chromosome chromosome = new(new int[] { 1, 2, 3, 4, 5, 6 });
            Mock<IArrayShuffler> mockArrayShuffler = new Mock<IArrayShuffler>();

            var range = Enumerable.Range(0, chromosome.Genomes.Length).ToArray();
            mockArrayShuffler.Setup(shuffler => shuffler.Shuffle(range))
                .Returns(new int[] { 1, 3, 5, 2, 4, 6 });


            var subject = new ThorosMutation(mockArrayShuffler.Object);
            int[] expected = new int[] { 1, 6, 3, 2, 5, 4 };

            var actual = subject.Mutate(chromosome);
            Assert.Equal(expected, actual.Genomes);
        }

        [Fact]
        public void TestTworsMutation()
        {
            Chromosome chromosome = new(new int[] { 1, 2, 3, 4, 5, 6 });
            Mock<Random> mockRandom = new Mock<Random>();

            mockRandom.SetupSequence(rand => rand.Next(chromosome.Genomes.Length))
                .Returns(3)
                .Returns(5);

            var subject = new TworsMutation(mockRandom.Object);
            int[] expected = new int[] { 1, 2, 3, 6, 5, 4 };

            var actual = subject.Mutate(chromosome);
            Assert.Equal(expected, actual.Genomes);
        }
    }
}
