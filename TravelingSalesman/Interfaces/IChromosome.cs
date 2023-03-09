namespace TravelingSalesman.Interfaces
{
    public interface IChromosome
    {
        static IData Data { get; set; }
        static readonly Random Rand = new Random();

        public int[] Genomes { get; set; }
        public double Fitness { get; set; }

        public IChromosome CreateChild(IChromosome second);

        public static abstract void SetData(IData data);

        public string ToString();
    }
}
