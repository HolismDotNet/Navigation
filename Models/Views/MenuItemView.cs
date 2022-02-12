namespace Navigation;

public class MenuItemView : IEntity, IGuid, ISlug, IKey, IOrder, IParent
{
    public MenuItemView()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public Guid Guid { get; set; }

    public string Url { get; set; }

    public Guid HierarchyGuid { get; set; }

    public string IsDirectory { get; set; }

    public Guid EntityTypeGuid { get; set; }

    public string Title { get; set; }

    public Guid? IconGuid { get; set; }

    public string IconSvg { get; set; }

    public long? ParentId { get; set; }

    public string Description { get; set; }

    public bool? Show { get; set; }

    public int? ItemsCount { get; set; }

    public string Slug { get; set; }

    public int? Level { get; set; }

    public bool? IsLeaf { get; set; }

    public long Order { get; set; }

    public string Key { get; set; }

    public string Path { get; set; }

    public dynamic RelatedItems { get; set; }
}