﻿using System.Xml;
using System.Xml.Linq;
using XMLOperations.Types;
using static XMLOperations.Configuration.OperationOptions;

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

        public static TreeNode? ToTreeNode(this XElement? element, TreeViewConfig? config = null)
        {
            if (element == null) return null;

            TreeNode node = new(element.Name.LocalName);

            var lineInfo = (IXmlLineInfo)element;

            if (lineInfo.LineNumber == 0)
                throw new ArgumentOutOfRangeException("File not loaded with option SetLineInfo LineNumber required.");

            node.LineNumber = lineInfo.LineNumber;
            var children = element.Elements();

            foreach (var child in children)
            {
                node.Children.Add(child.ToTreeNode(config)!);
            }

            if (config?.ShowAttributes ?? false)
            {
                foreach (var attribute in element.Attributes())
                {
                    node.Attributes.Add(attribute.Name.LocalName, attribute.Value);
                }
            }

            return node;
        }
    }
}