using TravelingSalesman.Chromosomes;

namespace TravelingSalesman.Data;

public class Graph : IData
{
    private readonly double[,] Table;
    public int Length;

    public Graph(double[,] table)
    {
        Length = table.GetLength(0);
        Table = table;
    }

    public Graph(City city)
    {
        Length = city.Graph.Vertex.Count;
        Table = new double[Length, Length];

        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < Length; j++)
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

    public double GetCycleLength(int[] path)
    {
        double length = 0;

        for (int i = 1; i < Table.GetLength(0); i++)
        {
            length += GetDistance(path[i - 1], path[i]);
        }
        length += GetDistance(path[^1], path[0]);

        return length;
    }

    public double GetFitness(Chromosome chromosome)
    {
        return GetCycleLength(chromosome.Genomes);
    }
}