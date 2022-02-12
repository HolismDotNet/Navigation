namespace Navigation;

public class MenuItem : IEntity, IGuid
{
    public MenuItem()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public Guid Guid { get; set; }

    public Guid HierarchyGuid { get; set; }

    public string Url { get; set; }

    public string IsDirectory { get; set; }

    public dynamic RelatedItems { get; set; }
}
