using System.Xml.Linq;

namespace XMLOperations
{
    public class Search
    {
        internal static IEnumerable<XElement> Filter(IEnumerable<XElement> query, Types.XmlNodeSearchModel model)
        {
            // filter by parent
            if (!string.IsNullOrEmpty(model.ParentName))
            {
                query = query.Where(x => x.Parent != null &&
                                    x.Parent.Name.LocalName == model.ParentName);
            }
            if (model.ParentFilter != null && !string.IsNullOrEmpty(model.ParentFilter.Attribute))
            {
                query = query.Where(x => x.Parent != null &&
                                    x.Parent.Attribute(model.ParentFilter.Attribute) != null &&
                                    x.Parent.Attribute(model.ParentFilter.Attribute).Value == model.ParentFilter.Value);
            }

            // filter by child
            if (!string.IsNullOrEmpty(model.ChildName))
            {
                query = query.Where(x => x.Elements().Any(y => y.Name.LocalName == model.ChildName));
            }
            if (model.ChildFilter != null && !string.IsNullOrEmpty(model.ChildFilter.Attribute))
            {
                query = query.Where(x => x.Elements().Any(y => y.Attribute(model.ChildFilter.Attribute) != null &&
                                                               y.Attribute(model.ChildFilter.Attribute).Value == model.ChildFilter.Value));
            }

            // search for what we are looking
            if (!string.IsNullOrEmpty(model.Searching))
            {
                query = query.Where(x => x.Name.LocalName == model.Searching);
            }
            if (model.SearchingFilter != null && !string.IsNullOrEmpty(model.SearchingFilter.Attribute))
            {
                query = query.Where(x => x.Attribute(model.SearchingFilter.Attribute) != null &&
                                         x.Attribute(model.SearchingFilter.Attribute).Value == model.SearchingFilter.Value);
            }

            return query;
        }
    }
}