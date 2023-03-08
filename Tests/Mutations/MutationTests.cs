using TravelingSalesman.Chromosomes;
using TravelingSalesman.Mutations;
using Moq;

namespace Tests.Mutations
{
    public class MutationTests
    {
        [Fact]
        public void TestCenterInverseMutation()
        {
            Chromosome chromosome = new( new int[] { 1,2,3,4,5,6});
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
    }
}
