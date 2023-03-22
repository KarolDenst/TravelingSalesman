using System.Diagnostics;
using TravelingSalesman;
using TravelingSalesman.Algorithms;
using TravelingSalesman.Data;
using TravelingSalesman.Factories;
using TravelingSalesman.Factories.Interfaces;
using TravelingSalesman.MatingStrategies;
using TravelingSalesman.Mutations;
using TravelingSalesman.TSPFitness;
using TravelingSalesman.Utils;

string cityName = "ch130";
string resultsDir = @"../../../../Results/";

City city = new City(Path.Combine(@"../../../../Cities/", cityName + ".xml"));
Graph graph = new Graph(city);
Random rand = new Random(0);

TSPFitnessCalculator fitnessCalculator = new TSPFitnessCalculator(graph);

IChromosomeFactory chromosomeFactory = new TSPChromosomeFactory(rand);

IMatingStrategy[] matingStrategies = new IMatingStrategy[] {
    new CycleX(),
    new OnePointX(Enumerable.Range(0, graph.Length).ToArray(), rand),
    new OrderX(rand), new OrderX2(rand),
    new PartiallyMappedX(rand)
};


IMutation[] mutations = new IMutation[]
{
    new CenterInverseMutation(rand),
    new ReverseSequenceMutation(rand),
    new ThorasMutation(rand),
    new ThorosMutation(new KnuthArrayShuffler(rand)),
    new TworsMutation(rand)
};

foreach (var matingStrategy in matingStrategies)
{
    string logDir = Path.Combine(resultsDir, matingStrategy.ToString()!.Replace(' ', '-'));

    if (!Directory.Exists(logDir))
        Directory.CreateDirectory(logDir);
    else
    {
        var dirInfo = new DirectoryInfo(logDir);
        foreach (var file in dirInfo.GetFiles())
        {
            file.Delete();
        }
    }

    foreach (var mutation in mutations)
    {
        GeneticAlgorithm algorithm = new(chromosomeLength: graph.Length,
            populationSize: 10, chromosomeFactory, matingStrategy, mutation, fitnessCalculator, rand);

        string id = matingStrategy.ToString()!.Replace(' ', '-') + "-" + mutation.ToString()!.Replace(' ', '-');
        string logPath = Path.Combine(logDir, cityName + "-" + id + ".txt");
        File.WriteAllText(logPath, string.Empty);

        algorithm.LogPath = logPath;

        Stopwatch sw = Stopwatch.StartNew();
        algorithm.Run(maxIterations: 200, crossoverProbability: 0.8, mutationProbability: 0.05, eliteSize: 0.25);
        //algorithm.RunDHMILC(0.005);
        sw.Stop();

        Console.WriteLine($"{matingStrategy} with {mutation}");
        Console.WriteLine($"Time elapsed: {sw.Elapsed.TotalMilliseconds} ms\n");
    }

    Plotter.PlotResults(logDir);
}

Console.WriteLine($"The results can be found in {Path.GetFullPath(resultsDir)}");
