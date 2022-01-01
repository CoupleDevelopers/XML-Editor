﻿using System.Xml.Linq;

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
        public static bool ContainsAttribute(this XElement element, Func<XAttribute,bool> predicate)
        {
            if (!element.HasAttributes) return false;

            return element.Attributes().Any(x => predicate(x));
        }

        /// <summary>
        /// Determines whether an XElement has localName.
        /// </summary>
        public static bool HasLocalName(this XElement element, string localName)
        => element.Name.LocalName == localName;

         
    }
}