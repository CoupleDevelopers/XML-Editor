namespace XMLOperations.Types;

/// <summary>
/// Client interface for node/element search on xml files
/// </summary>
internal class XmlNodeSearchModel
{
    public NodeFilter? ParentFilter { get; set; }
    public NodeFilter? ChildFilter { get; set; }
    public NodeFilter? SearchingFilter { get; set; }

}
