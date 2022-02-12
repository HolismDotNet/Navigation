namespace Navigation;

public class NavigationContext : DatabaseContext
{
    public override string ConnectionStringName => "Navigation";

    public DbSet<Navigation.LinkGroup> LinkGroups { get; set; }

    public DbSet<Navigation.Link> Links { get; set; }

    public DbSet<Navigation.MenuItem> MenuItems { get; set; }

    public DbSet<Navigation.MenuItemView> MenuItemViews { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<MenuItem>()
            .Property(p => p.IsDirectory)
            .HasComputedColumnSql("Url is null or trim(Url) != ''");
        base.OnModelCreating(builder);
    }
}
