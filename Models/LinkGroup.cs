namespace Menu;

public class LinkGroup : IEntity, IKey
{
    public LinkGroup()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public string Title { get; set; }

    public string Key { get; set; }

    public dynamic RelatedItems { get; set; }
}
