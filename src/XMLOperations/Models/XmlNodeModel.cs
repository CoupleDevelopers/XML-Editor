using System.Xml;

namespace XMLOperations.Types;


internal class XmlNodeModel
{
    public XmlNodeModel Current { get; set; }
    public XmlNodeModel Parent { get; set; }

    public XmlNodeList Children { get; set; }
}
