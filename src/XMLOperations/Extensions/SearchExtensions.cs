using System.Runtime.CompilerServices;
using System.Xml.Linq;
using XMLOperations.Types;
[assembly: InternalsVisibleTo("XMLOperations.Tests")]

namespace XMLOperations.Extensions
{
    internal static class SearchExtensions
    {
        /// <summary>
        /// Filters xml nodes regarding given filter model
        /// </summary>
        /// <param name="query">root XElement to be filtered</param>
        /// <param name="model">requested filter pattern</param>
        internal static IEnumerable<XElement> Filter(IEnumerable<XElement> query, XmlNodeSearchModel model)
        {
            if (model.ParentFilter != null && model.ParentFilter.IsValid)
                query = query.Filter(model.ParentFilter, x => x.Parent!);

            if (model.SearchingFilter != null && model.SearchingFilter.IsValid)
                query = query.Filter(model.SearchingFilter, x => x);

            if (model.ChildFilter != null && model.ChildFilter.IsValid)
                query = query.FilterChildren(model.ChildFilter, x => x);

            return query;
        }

        /// <summary>
        /// Filters xml nodes regarding given filter model
        /// </summary>
        private static IEnumerable<XElement> Filter
            (this IEnumerable<XElement> query, NodeFilter filter, Func<XElement, XElement> elementPicker)
        {
            if (!filter.IsValid)
                throw new ArgumentException("Filter has no header and attributes values");


#pragma warning disable CS8604 // Possible null reference argument.
            if (filter.HasHeaderName)
            {
                query = query.FilterByHeaderName(filter.HeaderName, elementPicker);
            }

            if (filter.HasAttributeFilters)
            {
                query = query.FilterByAttributes(filter.AttributeFilters, elementPicker);
            }
#pragma warning restore CS8604 // Possible null reference argument.

            return query;
        }

        /// <summary>
        /// Filters immediate child nodes regarding given filter model
        /// </summary>
        private static IEnumerable<XElement> FilterChildren(this IEnumerable<XElement> query,
            NodeFilter filter, Func<XElement, XElement> elementPicker)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));
            if (!filter.IsValid) throw new ArgumentException($"{nameof(filter)} is not valid");

            query = query.Where(x => x.HasElements);

            if (filter.HeaderName != null)
                query = query.Where(x => x.Elements().FilterByHeaderName(filter.HeaderName, elementPicker).Any());

            if (filter.AttributeFilters != null)
                query = query.Where(x => x.Elements().FilterByAttributes(filter.AttributeFilters, elementPicker).Any());

            return query;
        }

        /// <summary>
        /// Filters xml nodes having given [attribute, value] pairs
        /// </summary>
        private static IEnumerable<XElement> FilterByAttributes(this IEnumerable<XElement> query,
            List<NodeAttributeFilter> filters, Func<XElement, XElement> elementPicker)
        {
            if (filters == null || !filters.Any())
                throw new ArgumentException($"{nameof(filters)} required");

            foreach (NodeAttributeFilter filter in filters)
            {
                query = query.FilterByAttribute(filter, elementPicker);
            }

            return query;
        }

        /// <summary>
        /// Filters xml nodes having given element name
        /// </summary>
        private static IEnumerable<XElement> FilterByHeaderName
            (this IEnumerable<XElement> query, string headerName, Func<XElement, XElement> elementPicker)
        {
            if (string.IsNullOrWhiteSpace(headerName))
                throw new ArgumentException($"{nameof(headerName)} is required");

            return query.Where(x => elementPicker(x) != null && elementPicker(x).HasLocalName(headerName));
        }

        /// <summary>
        /// Filters xml nodes having given [attribute, value] pair
        /// </summary>
        private static IEnumerable<XElement> FilterByAttribute
            (this IEnumerable<XElement> query, NodeAttributeFilter attributeFilter, Func<XElement, XElement?> elementPicker)
        {
            if (elementPicker == null)
                throw new ArgumentNullException($"{nameof(elementPicker)} is null");

            if (attributeFilter == null || !attributeFilter.IsValid)
                throw new ArgumentException($"{nameof(attributeFilter)} is not valid");

            return query.Where(x => elementPicker(x) != null && elementPicker(x).ContainsAttribute(attributeFilter.Attribute, attributeFilter.Value));
        }
    }
}