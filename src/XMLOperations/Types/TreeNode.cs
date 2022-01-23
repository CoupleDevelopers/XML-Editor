namespace XMLOperations.Types;

public class TreeNode
{
    public TreeNode(string name)
    {
        Name = name;
        Attributes = new Dictionary<string, string>();
    }

    public string Name { get; set; }

    public Dictionary<string, string> Attributes { get; private set; }

    public int ChildrenCount => Children.Count;

    public string AttributesString => string.Join(" ", Attributes.Select(x => $"{x.Key}=\"{x.Value}\""));

    public List<TreeNode> Children { get; set; } = new List<TreeNode>();
}