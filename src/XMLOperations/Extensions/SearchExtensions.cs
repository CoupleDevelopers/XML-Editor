using System.Xml.Linq;
using XMLOperations.Types;

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
            if (model.ParentFilter == null && model.SearchingFilter == null && model.ChildFilter == null)
                return query;

            return query
                .Filter(model.ParentFilter, (x) => x.Parent)
                .Filter(model.SearchingFilter, (x) => x)
                .ChildFilter(model.ChildFilter, (x) => x);
        }

        /// <summary>
        /// Filters xml nodes regarding given filter model
        /// </summary>
        private static IEnumerable<XElement> Filter
            (this IEnumerable<XElement> query, NodeFilter? filter, Func<XElement, XElement?> func)
            => query.CheckForHeaderName(filter?.HeaderName, func).CheckForAttributesFilter(filter?.AttributeFilters, func);

        /// <summary>
        /// Filters immediate child nodes regarding given filter model
        /// </summary>
        private static IEnumerable<XElement> ChildFilter
            (this IEnumerable<XElement> query, NodeFilter? filter, Func<XElement, XElement> func)
            => query.SelectMany(x => x.Elements().CheckForHeaderName(filter?.HeaderName, func).CheckForAttributesFilter(filter?.AttributeFilters, func));

        /// <summary>
        /// Filters xml nodes having given element name
        /// </summary>
        private static IEnumerable<XElement> CheckForHeaderName
            (this IEnumerable<XElement> query, string? headerName, Func<XElement, XElement?> element)
            => string.IsNullOrWhiteSpace(headerName) ? query : query.Where(x => element(x)?.Name.LocalName == headerName);

        /// <summary>
        /// Filters xml nodes having given [attribute, value] pairs
        /// </summary>
        private static IEnumerable<XElement> CheckForAttributesFilter
            (this IEnumerable<XElement> query, List<NodeAttributeFilter>? filters, Func<XElement, XElement?> checkFunction)
        {
            if (filters == null || !filters.Any())
                return query;

            foreach (NodeAttributeFilter filter in filters)
            {
                query = query.CheckForAttributeFilter(filter, checkFunction);
            }

            return query;
        }

        /// <summary>
        /// Filters xml nodes having given [attribute, value] pair
        /// </summary>
        private static IEnumerable<XElement> CheckForAttributeFilter
            (this IEnumerable<XElement> query, NodeAttributeFilter filter, Func<XElement, XElement?> element)
            => !filter.IsValid ? query : query.Where(x => element(x)?.Attributes().Any(x => x.Name.LocalName == filter.Attribute && x.Value == filter.Value) != null);
    }
}