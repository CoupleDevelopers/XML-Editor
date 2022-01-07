using System.Collections.Generic;

namespace XMLEditor.Model;

internal class Tree
{
    public string Name { get; set; }
    public int ChildrenCount => Children.Count;
    public List<Tree> Children { get; set; } = new List<Tree>();
}