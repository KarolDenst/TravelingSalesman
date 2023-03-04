using System.Xml.Serialization;

namespace TravelingSalesman;

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