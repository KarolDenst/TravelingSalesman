// See https://aka.ms/new-console-template for more information

using System.Xml.Serialization;
using TravelingSalesman;

City city = new City(@"C:\Projects\TravelingSalesman\Cities\br17.xml");

Graph graph = new Graph(city);

Console.WriteLine("Hello, World!");