namespace TravelingSalesman.Utils
{
    public class KnuthArrayShuffler : IArrayShuffler
    {
        private readonly Random rand;
        public KnuthArrayShuffler(Random rand)
        {
            this.rand = rand;
        }

        public T[] Shuffle<T>(T[] array)
        {
            int n = array.Length;
            T[] shuffled = new T[n];
            Array.Copy(array, shuffled, n);
            while (n > 1)
            {
                int k = rand.Next(n--);
                (shuffled[n], shuffled[k]) = (shuffled[k], shuffled[n]);
            }

            return shuffled;
        }
    }
}
