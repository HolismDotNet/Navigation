namespace Menu;

public class MenuItem : IEntity, IGuid, IOrder
{
    public MenuItem()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public Guid Guid { get; set; }

    public string Url { get; set; }

    public string IsDirectory { get; set; }

    public long Order { get; set; }

    public dynamic RelatedItems { get; set; }
}
