namespace TravelingSalesman;

public class Graph
{
    private double[,] Table;

    public Graph(double[,] table)
    {
        if (table.GetLength(0) != table.GetLength((1)))
            throw new ArgumentException("Dimensions do not agree");
        Table = table;
    }

    public Graph(City city)
    {
        int length = city.Graph.Vertex.Count;
        Table = new double[length, length];

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                Table[i, j] = city.Graph.Vertex[i].Edge[j].Cost;
            }
        }
    }

    public bool AreNeighbors(int from, int to)
    {
        return Table[from, to] > 0;
    }

    public double GetDistance(int from, int to)
    {
        return Table[from, to];
    }

    public double GetPathLength(int[] path)
    {
        double length = 0;

        for (int i = 1; i < Table.GetLength(0); i++)
        {
            length += GetDistance(path[i - 1], path[i]);
        }

        return length;
    }
}