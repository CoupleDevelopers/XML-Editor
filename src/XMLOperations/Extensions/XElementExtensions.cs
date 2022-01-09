using System.Xml.Linq;
using XMLOperations.Types;

namespace XMLOperations.Extensions
{
    public static class XElementExtensions
    {
        /// <summary>
        /// Determines whether an XElement contains a specified attribute by <see cref="XName.LocalName"/>
        /// <br />with <paramref name="withValue"/> if provided.
        /// </summary>
        public static bool ContainsAttribute(this XElement element, string attribute, string? withValue = null)
        {
            if (!element.HasAttributes) return false;

            return element.Attributes().Any(x => x.Name.LocalName == attribute && (withValue == null || x.Value == withValue));
        }

        /// <summary>
        /// Determines whether an XElement contains a specified attribute using <paramref name="predicate"/> function.
        /// </summary>
        public static bool ContainsAttribute(this XElement element, Func<XAttribute, bool> predicate)
        {
            if (!element.HasAttributes) return false;

            return element.Attributes().Any(x => predicate(x));
        }

        /// <summary>
        /// Determines whether an XElement has localName.
        /// </summary>
        public static bool HasLocalName(this XElement element, string localName) => element.Name.LocalName == localName;

        /// <summary>
        /// Determines whether an XElement has given inner text
        /// </summary>
        public static bool HasInnerText(this XElement element, string innerText) => element.Value == innerText;

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