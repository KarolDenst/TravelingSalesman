using TravelingSalesman;
using TravelingSalesman.Factories;

City city = new City(@"C:\Projects\TravelingSalesman\Cities\br17.xml");
double[,] map = new double[,] {
            { 0, 2, 9999, 12, 5 },
            { 2, 0, 4, 8, 9999 },
            { 9999, 4, 0, 3, 3 },
            { 12, 8, 3, 0, 10 },
            { 5, 9999, 3, 10, 0 } };

Graph graph = new Graph(map);
TSPChromosomeFactory factory = new TSPChromosomeFactory();
TSPChromosome.SetData(graph);

EvolutionaryAlgo algo = new EvolutionaryAlgo(graph.Length, 10, factory);
algo.Run(50);

Console.WriteLine(algo.ToString());