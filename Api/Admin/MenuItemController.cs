namespace Navigation;

public class MenuItemController : TreeController<MenuItemView, MenuItem>
{
    public override TreeBusiness<MenuItemView, MenuItem> Business => new MenuItemBusiness();

    public override ReadBusiness<MenuItemView> ReadBusiness => new MenuItemBusiness();
}