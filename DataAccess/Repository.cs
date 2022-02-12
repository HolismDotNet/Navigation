namespace Navigation;

public class Repository
{
    public static Write<Navigation.LinkGroup> LinkGroup
    {
        get
        {
            return new Write<Navigation.LinkGroup>(new NavigationContext());
        }
    }

    public static Write<Navigation.Link> Link
    {
        get
        {
            return new Write<Navigation.Link>(new NavigationContext());
        }
    }

    public static Write<Navigation.MenuItem> MenuItem
    {
        get
        {
            return new Write<Navigation.MenuItem>(new NavigationContext());
        }
    }

    public static Write<Navigation.MenuItemView> MenuItemView
    {
        get
        {
            return new Write<Navigation.MenuItemView>(new NavigationContext());
        }
    }
}
