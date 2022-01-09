namespace XMLOperations.Types;

public class TreeNode
{
    public string Name { get; set; }
    public int ChildrenCount => Children.Count;
    public List<TreeNode> Children { get; set; } = new List<TreeNode>();
}