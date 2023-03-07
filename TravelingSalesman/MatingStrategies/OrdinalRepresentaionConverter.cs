namespace TravelingSalesman.MatingStrategies
{
    public class OrdinalRepresentaionConverter
    {
        public static int[] ToOrdinalRepresentation(int[] currentTour, int[] canonicTour)
        {
            List<int> ordinalRepresentation = new();
            List<int> canonic = new(canonicTour);
            foreach (int c in currentTour)
            {
                ordinalRepresentation.Add(canonic.IndexOf(c));
                canonic.Remove(c);
            }

            return ordinalRepresentation.ToArray();
        }

        public static int[] FromOrdinalRepresentaion(int[] ordinalRepresentaation, int[] canonicTour)
        {
            List<int> tour = new();
            List<int> canonic = new(canonicTour);

            foreach (int i in ordinalRepresentaation)
            {
                int c = canonic[i];
                tour.Add(c);
                canonic.Remove(c);
            }

            return tour.ToArray();
        }
    }
}
