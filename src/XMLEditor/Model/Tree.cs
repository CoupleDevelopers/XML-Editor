using System.Collections.Generic;

namespace XMLEditor.Model;

internal class Tree
{
    public string Name { get; set; }
    public int ChildrenCount { get; set; }
    public List<Tree> Children { get; set; }
}