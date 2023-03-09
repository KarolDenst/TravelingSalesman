using System.Diagnostics;
using System.Configuration;
using TravelingSalesman;
using TravelingSalesman.Algorithms;
using TravelingSalesman.Data;
using TravelingSalesman.Factories;
using TravelingSalesman.Factories.Interfaces;
using TravelingSalesman.MatingStrategies;
using TravelingSalesman.Mutations;
using TravelingSalesman.TSPFitness;

City br17 = new City(@"../../../../Cities/br17.xml");
Graph graphBr17 = new Graph(br17);

Random rand = new Random(0);

IChromosomeFactory chromosomeFactory = new TSPChromosomeFactory(rand);
IMatingStrategy matingStrategy = new PartiallyMappedX(rand);
IMutation mutation = new ReverseSequenceMutation(rand);
TSPFitnessCalculator fitnessCalculator = new TSPFitnessCalculator(graphBr17);

GeneticAlgorithm geneticAlgorithm = new GeneticAlgorithm(chromosomeLength: graphBr17.Length,
    populationSize: 50, chromosomeFactory, matingStrategy, mutation, fitnessCalculator);

string logPath = @"../../../../Results/br17.txt";
File.WriteAllText(logPath, string.Empty);

geneticAlgorithm.LogPath = logPath;
geneticAlgorithm.Run(200, 0.8, 0.01);
//geneticAlgorithm.RunDHMILC(0.005);

Console.WriteLine($"The results can be found in {Path.GetFullPath(logPath)}\n");
string pythonPath = ConfigurationManager.AppSettings.Get("python_path") 
    ?? throw new Exception("Invalid configuration");
PlotResults(pythonPath, logPath, $"\"TSP using {matingStrategy} and {mutation}\"");


static void PlotResults(string pythonPath, string resultsPath, string title)
{
    string plotScriptPath = @"../../../../Script/plot_results.py";
    ProcessStartInfo start = new ProcessStartInfo();
    start.FileName = pythonPath;
    start.Arguments = string.Format("{0} {1} {2}", plotScriptPath, resultsPath, title);
    start.UseShellExecute = false;
    Process.Start(start);
}

