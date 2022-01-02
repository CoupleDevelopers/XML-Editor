using System.ComponentModel.DataAnnotations;

namespace XMLOperations.Types;

/// <summary>
/// To be used for attribute filtering on node/element search
/// </summary>
public class NodeFilter
{
    public string? HeaderName { get; set; }
    public List<NodeAttributeFilter>? AttributeFilters { get; set; }

    public bool IsValid =>  HasHeaderName || HasAttributeFilters;

    public bool HasHeaderName => !string.IsNullOrWhiteSpace(HeaderName);
    public bool HasAttributeFilters=> (AttributeFilters != null && AttributeFilters.Count > 0);
}
