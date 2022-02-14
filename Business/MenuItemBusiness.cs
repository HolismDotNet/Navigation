namespace Navigation;

public class MenuItemBusiness : TreeBusiness<MenuItemView, MenuItem>
{
    protected override Read<MenuItemView> Read => Repository.MenuItemView;

    protected override Write<MenuItem> Write => Repository.MenuItem;

    protected override long GetNodeId(MenuItemView node)
    {
        return node.HierarchyId;
    }
}