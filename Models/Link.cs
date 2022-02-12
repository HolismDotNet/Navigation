namespace Navigation;

public class Link : IEntity
{
    public Link()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public long LinkGroupId { get; set; }

    public string Url { get; set; }

    public dynamic RelatedItems { get; set; }
}
