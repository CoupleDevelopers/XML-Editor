using System.Collections.Generic;

namespace XMLEditor.Model;

internal class TreeNode
{
    public string Name { get; set; }
    public int ChildrenCount => Children.Count;
    public List<TreeNode> Children { get; set; } = new List<TreeNode>();
}