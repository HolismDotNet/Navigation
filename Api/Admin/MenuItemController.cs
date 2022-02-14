namespace Navigation;

public class MenuItemController : TreeController<MenuItemView, MenuItem>
{
    public override TreeBusiness<MenuItemView, MenuItem> Business => new MenuItemBusiness();

    public override ReadBusiness<MenuItemView> ReadBusiness => new MenuItemBusiness();

    public override Action<MenuItem> PreCreation => menuItem =>
    {
        var title = HttpContext.ExtractProperty("Title").ToString();
        var parentId = HttpContext.ExtractProperty("parentId");
        var hierarchy = new HierarchyBusiness().Create(new MenuItemBusiness().EntityType, title, parentId == null ? null : parentId.ToString().ToLong());
        menuItem.HierarchyGuid = hierarchy.Guid;
    };

    public override Action<MenuItem> PreUpdate => menuItem =>
    {
        var title = HttpContext.ExtractProperty("Title").ToString();
        var hierarchyGuid = Business.Get(menuItem.Id).HierarchyGuid;
        new HierarchyBusiness().UpdateTitle(hierarchyGuid, title);
    };

    public override Action<long> PreDeletion => id =>
    {
        var hierarchyGuid = Business.Get(id).HierarchyGuid;
        new HierarchyBusiness().Delete(hierarchyGuid);
    };
}