namespace Menu;

public class Repository
{
    public static Write<Menu.LinkGroup> LinkGroup
    {
        get
        {
            return new Write<Menu.LinkGroup>(new MenuContext());
        }
    }

    public static Write<Menu.Link> Link
    {
        get
        {
            return new Write<Menu.Link>(new MenuContext());
        }
    }

    public static Write<Menu.MenuItem> MenuItem
    {
        get
        {
            return new Write<Menu.MenuItem>(new MenuContext());
        }
    }
}
