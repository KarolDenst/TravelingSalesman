/*City city = new(@"C:\Projects\TravelingSalesman\Cities\br17.xml");
double[,] map = new double[,] {
            { 0, 2, 9999, 12, 5 },
            { 2, 0, 4, 8, 9999 },
            { 9999, 4, 0, 3, 3 },
            { 12, 8, 3, 0, 10 },
            { 5, 9999, 3, 10, 0 } };

Graph graph = new(map);
TSPChromosomeFactory factory = new();
IMatingStrategy matingStrategy = new OrderX2();
TSPFitnessCalculator fitnessCalculator = new(graph);

EvolutionaryAlgo algo = new(graph.Length, 10, factory, matingStrategy, fitnessCalculator);
algo.Run(50);

Console.WriteLine(algo.ToString());
*/
/*Chromosome chromosome = new(new int[] { 1, 2, 3, 4, 5 });
*//*TworsMutation twors = new TworsMutation();
Console.WriteLine(twors.Mutate(chromosome));*//*

CenterInverseMutation centerInverse = new();
Console.WriteLine(centerInverse.Mutate(chromosome));*/
Console.WriteLine("Hello world!");