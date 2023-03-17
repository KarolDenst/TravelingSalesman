using System.Configuration;
using TravelingSalesman;
using TravelingSalesman.Algorithms;
using TravelingSalesman.Data;
using TravelingSalesman.Factories;
using TravelingSalesman.Factories.Interfaces;
using TravelingSalesman.MatingStrategies;
using TravelingSalesman.Mutations;
using TravelingSalesman.TSPFitness;

string cityName = "br17";

City city = new City(Path.Combine(@"../../../../Cities/", cityName + ".xml"));
Graph graphBr17 = new Graph(city);

Random rand = new Random(0);

IChromosomeFactory chromosomeFactory = new TSPChromosomeFactory(rand);
IMatingStrategy matingStrategy = new PartiallyMappedX(rand);
IMutation mutation = new ReverseSequenceMutation(rand);
TSPFitnessCalculator fitnessCalculator = new TSPFitnessCalculator(graphBr17);

//GeneticAlgorithm algorithm = new GeneticAlgorithm(chromosomeLength: graphBr17.Length,
//    populationSize: 50, chromosomeFactory, matingStrategy, mutation, fitnessCalculator);
EvolutionaryAlgorithm algorithm = new EvolutionaryAlgorithm(chromosomeLength: graphBr17.Length,
    populationSize: 50, chromosomeFactory, matingStrategy, fitnessCalculator);

string logPath = Path.Combine(@"../../../../Results/", cityName + ".txt");
File.WriteAllText(logPath, string.Empty);

algorithm.LogPath = logPath;
algorithm.Run(200, 0.8, 0.01);
//geneticAlgorithm.RunDHMILC(0.005);

Console.WriteLine($"The results can be found in {Path.GetFullPath(logPath)}\n");
string pythonPath = ConfigurationManager.AppSettings.Get("python_path") 
    ?? throw new Exception("Invalid configuration");
Plotter.PlotResults(logPath, $"\"TSP using {matingStrategy} and {mutation}\"");
