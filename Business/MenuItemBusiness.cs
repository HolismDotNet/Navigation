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

    public Dictionary<string, object> LoadCache()
    {
        var result = new Dictionary<string, object>();
        var menu = GetTree();
        result.Add("Menu", Modify(menu));
        return result;
    }

    private object Modify(List<MenuItemView> menu)
    {
        var modified = new List<dynamic>();
        foreach (var item in menu)
        {
            dynamic modifiedItem = new ExpandoObject();
            modifiedItem.Id = item.Id;
            modifiedItem.Url = item.Url;
            modifiedItem.IsDirectory = item.IsDirectory;
            modifiedItem.Title = item.Title;
            modifiedItem.IconSvg = item.IconSvg;
            modifiedItem.IsLeaf = item.IsLeaf;
            if (item.RelatedItems.Children.Count > 0)
            {
                modifiedItem.Children = Modify(item.RelatedItems.Children);
            }
            modified.Add(modifiedItem);
        }
        return modified;
    }
}