namespace XMLOperations.Types;

public class TreeNode
{
    public TreeNode(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

#warning TreeView needs to be updated for attributes.
    public Dictionary<string, string> Attributes { get; set; }

    public int ChildrenCount => Children.Count;
    public List<TreeNode> Children { get; set; } = new List<TreeNode>();
}