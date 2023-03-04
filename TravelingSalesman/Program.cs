// See https://aka.ms/new-console-template for more information

using System.Xml.Serialization;
using TravelingSalesman;

XmlSerializer ser = new XmlSerializer(typeof(City));
string filename = @"C:\Projects\TravelingSalesman\Cities\br17.xml";
City city;
using (Stream reader = new FileStream(filename, FileMode.Open))
{
    // Call the Deserialize method to restore the object's state.
    city = (City)ser.Deserialize(reader);
}

Graph graph = new Graph(city);

Console.WriteLine("Hello, World!");