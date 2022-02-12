namespace Menu;

public class Repository
{
    public static Repository<Menu.LinkGroup> LinkGroup
    {
        get
        {
            return new Repository<Menu.LinkGroup>(new MenuContext());
        }
    }

    public static Repository<Menu.Link> Link
    {
        get
        {
            return new Repository<Menu.Link>(new MenuContext());
        }
    }

    public static Repository<Menu.MenuItem> MenuItem
    {
        get
        {
            return new Repository<Menu.MenuItem>(new MenuContext());
        }
    }
}
