namespace XMLOperations.Types;

/// <summary>
/// To be used for attribute filtering on node/element search
/// </summary>
public class NodeFilter
{
    public string? HeaderName { get; set; }
    public string? InnerText { get; set; }
    public List<NodeAttributeFilter>? AttributeFilters { get; set; }
    public bool IsValid => HasHeaderName || HasAttributeFilters || HasInnerText;
    public bool HasHeaderName => !string.IsNullOrWhiteSpace(HeaderName);
    public bool HasInnerText => InnerText != null;
    public bool HasAttributeFilters => (AttributeFilters != null && AttributeFilters.Count > 0);
}