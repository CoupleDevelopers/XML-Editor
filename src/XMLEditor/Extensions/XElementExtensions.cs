using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XMLEditor.Model;

namespace XMLEditor.Extensions
{
    internal static class XElementExtensions
    {
        public static TreeNode? ToTreeNode(this XElement? element)
        {
            if (element == null) return null;

            TreeNode node = new()
            {
                Name = element.Name.LocalName
            };

            var childs = element.Elements();

            foreach (var child in childs)
            {
                node.Children.Add(child.ToTreeNode()!);
            }

            return node;
        }
    }
}