using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XMLOperations.Types;

namespace XMLOperations.Extensions
{
    internal static class SearchExtensions
    {

        internal static IEnumerable<XElement> Filter(IEnumerable<XElement> query, XmlNodeSearchModel model)
        {
            if (model.ParentFilter == null && model.SearchingFilter == null && model.ChildFilter == null)
                return query;



            return query
                .CheckForFilter(model.ParentFilter, (x) => x.Parent)
                .CheckForFilter(model.SearchingFilter, (x) => x)
                .CheckForChildsFilter(model.ChildFilter, (x) => x);
        }

        /// <summary>
        /// 
        /// </summary> 
        private static IEnumerable<XElement> CheckForFilter
            (this IEnumerable<XElement> query, NodeFilter? filter, Func<XElement, XElement?> func)
            => query.CheckForHeaderName(filter?.HeaderName, func).CheckForAttributesFilter(filter?.AttributeFilters, func);

        /// <summary>
        /// 
        /// </summary>
        private static IEnumerable<XElement> CheckForHeaderName
            (this IEnumerable<XElement> query, string? headerName, Func<XElement, XElement?> element)
            => string.IsNullOrWhiteSpace(headerName) ?
            throw new ArgumentException($"{nameof(headerName)} is not valid!")
            : query.Where(x => element(x)?.Name.LocalName == headerName);

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

        #region Children

        /// <summary>
        /// 
        /// </summary> 
        private static IEnumerable<XElement> CheckForChildsFilter
            (this IEnumerable<XElement> query, NodeFilter? filter, Func<XElement, XElement> func)
            => query.CheckForChildsHeaderName(filter?.HeaderName, func).CheckForChildsAttributeFilter(filter?.AttributeFilters, func);


        /// <summary>
        /// 
        /// </summary> 
        private static IEnumerable<XElement> CheckForChildsHeaderName
            (this IEnumerable<XElement> query, string? headerName, Func<XElement, XElement> element)
            => string.IsNullOrWhiteSpace(headerName) ? query : query.SelectMany(x => x.Elements().CheckForHeaderName(headerName, element));


        /// <summary>
        /// 
        /// </summary>
        private static IEnumerable<XElement> CheckForChildsAttributeFilter
             (this IEnumerable<XElement> query, List<NodeAttributeFilter>? filters, Func<XElement, XElement> element)
        {
            if (filters == null || !filters.Any())
                return query;

            foreach (NodeAttributeFilter filter in filters)
            {
                query = query.CheckForChildsAttributeFilter(filter, element);
            }

            return query;

        }

        /// <summary>
        /// 
        /// </summary> 
        private static IEnumerable<XElement> CheckForChildsAttributeFilter
         (this IEnumerable<XElement> query, NodeAttributeFilter filter, Func<XElement, XElement> element)
         => !filter.IsValid ? query : query.SelectMany(x => x.Elements().CheckForAttributeFilter(filter, element));

        #endregion

        /// <summary>
        /// 
        /// </summary>
        private static IEnumerable<XElement> CheckForAttributeFilter
            (this IEnumerable<XElement> query, NodeAttributeFilter filter, Func<XElement, XElement?> element)
            => !filter.IsValid ? query : query.Where(x => element(x)?.Attributes().Any(x => x.Name == filter.Attribute && (x.Value ?? "") == filter.Value) != null);
    }
}
