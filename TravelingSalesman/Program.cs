using System.Diagnostics;
using System.Runtime.CompilerServices;
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

Random rand = new Random();

IChromosomeFactory chromosomeFactory = new TSPChromosomeFactory();
IMatingStrategy matingStrategy = new CycleX();
IMutation mutation = new ReverseSequenceMutation(rand);
TSPFitnessCalculator fitnessCalculator = new TSPFitnessCalculator(graphBr17);

GeneticAlgorithm geneticAlgorithm = new GeneticAlgorithm(chromosomeLength: graphBr17.Length,
    populationSize: 40, chromosomeFactory, matingStrategy, mutation, fitnessCalculator);

string logPath = @"../../../../Results/br17.txt";
File.WriteAllText(logPath, string.Empty);

geneticAlgorithm.LogPath = logPath;
geneticAlgorithm.Run(200, 0.1);

Console.WriteLine($"The results can be found in {Path.GetFullPath(logPath)}\n");
string pythonPath = @"C:\Python311\python.exe";
PlotResults(pythonPath, logPath, $"\"TSP using {matingStrategy.ToString()} and {mutation.ToString()}\"");


void PlotResults(string pythonPath, string resultsPath, string title)
{
    string plotScriptPath = @"../../../../Script/plot_results.py";
    ProcessStartInfo start = new ProcessStartInfo();
    start.FileName = pythonPath;
    start.Arguments= string.Format("{0} {1} {2}", plotScriptPath, resultsPath, title);
    start.UseShellExecute = false;
    Process.Start(start);
}

