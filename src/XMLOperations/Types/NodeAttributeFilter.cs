namespace XMLOperations.Types
{
    public class NodeAttributeFilter
    {
        public NodeAttributeFilter(string attribute, string value)
        {
            Attribute = attribute;
            Value = value;
        }

        public string Attribute { get; set; }
        public string Value { get; set; }

        public bool IsValid => Attribute != null;
    }
}