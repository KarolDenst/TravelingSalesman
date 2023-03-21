using TravelingSalesman.Data;

namespace TravelingSalesmanGUI
{
    internal class Utils
    {
        public static Graph GetGraph(Point[] points)
        {
            var table = new double[points.Length, points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    double distance = GetDistance(points[i], points[j]);
                    table[i, j] = distance;
                    table[j, i] = distance;
                }
            }

            return new Graph(table);
        }

        private static double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }
    }
}
