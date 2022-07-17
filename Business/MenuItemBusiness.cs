namespace Navigation;

public class MenuItemBusiness : TreeBusiness<MenuItemView, MenuItem>
{
    protected override Read<MenuItemView> Read => Repository.MenuItemView;

    protected override Write<MenuItem> Write => Repository.MenuItem;

    public object GetMenu()
    {
        var menu = Cache.Get("Menu");
        if (menu != null) 
        {
            return menu;
        }
        menu = GetTree();
        return menu;
    }

    protected override long GetNodeId(MenuItemView node)
    {
        return node.HierarchyId;
    }

    public Dictionary<string, List<MenuItemView>> LoadCache()
    {
        var result = new Dictionary<string, List<MenuItemView>>();
        var menu = GetTree();
        result.Add("Menu", menu);
        return result;
    }
}