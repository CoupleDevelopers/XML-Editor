using System.Xml;

namespace XMLOperations
{
    internal class Types
    {
        /// <summary>
        /// Client interface for node/element search on xml files
        /// </summary>
        public class XmlNodeSearchModel
        {
            public string RootFolder { get; set; }
            public string ParentName { get; set; }
            public NodeFilter ParentFilter { get; set; }
            public string ChildName { get; set; }
            public NodeFilter ChildFilter { get; set; }
            public string Searching { get; set; }
            public NodeFilter SearchingFilter { get; set; }
        }

        /// <summary>
        /// To be used for attribute filtering on node/element search
        /// </summary>
        public class NodeFilter
        {
            public string Attribute { get; set; }
            public string Value { get; set; }
        }
        
        /// <summary>
        /// Optional configuration for searched pattern
        /// </summary>
        class Config
        {
            private bool SearchAll { get; set; }
        }

        public class XmlNodeModel
        {
            public XmlNodeModel Current { get; set; }
            public XmlNodeModel Parent { get; set; }
            public XmlNodeList Children { get; set; }
        }
    }
}
