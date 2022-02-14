namespace Navigation;

public class MenuItemController : TreeController<MenuItemView, MenuItem>
{
    public override TreeBusiness<MenuItemView, MenuItem> Business => new MenuItemBusiness();

    public override ReadBusiness<MenuItemView> ReadBusiness => new MenuItemBusiness();

    public override Action<MenuItem> PreCreation => menuItem =>
    {
        var title = HttpContext.ExtractProperty("Title").ToString();
        var hierarchy = new HierarchyBusiness().Create(new MenuItemBusiness().EntityType, title);
        menuItem.HierarchyGuid = hierarchy.Guid;
    };

    public override Action<MenuItem> PreUpdate => menuItem => 
    {
        var title = HttpContext.ExtractProperty("Title").ToString();
        var hierarchyGuid = Business.Get(menuItem.Id).HierarchyGuid;
        new HierarchyBusiness().UpdateTitle(hierarchyGuid, title);
    };
}