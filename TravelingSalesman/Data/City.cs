using System.Xml.Serialization;

namespace TravelingSalesman.Data;

[XmlRoot("travellingSalesmanProblemInstance")]
public class City
{
    [XmlElement("name")]
    public string Name;
    [XmlElement("source")]
    public string Source;
    [XmlElement("description")]
    public string Description;
    [XmlElement("doublePrecision")]
    public int DoublePrecision;
    [XmlElement("ignoredDigits")]
    public int IgnoredDigits;

    [XmlElement("graph")]
    public GraphInstance Graph;

    public City() { }

    public City(string filename)
    {
        XmlSerializer ser = new XmlSerializer(typeof(City));
        City city;
        using (Stream reader = new FileStream(filename, FileMode.Open))
        {
            // Call the Deserialize method to restore the object's state.
            city = (City)ser.Deserialize(reader);
        }

        Name = city.Name;
        Source = city.Source;
        Description = city.Description;
        DoublePrecision = city.DoublePrecision;
        IgnoredDigits = city.IgnoredDigits;
        Graph = city.Graph;
    }
}

public class GraphInstance
{
    [XmlElement("vertex")]
    public List<VertexInstance> Vertex;
}

public class VertexInstance
{
    [XmlElement("edge")]
    public List<EdgeInstance> Edge;
}

public class EdgeInstance
{
    [XmlAttribute("cost")]
    public double Cost;
    [XmlText]
    public int Vertex;
}