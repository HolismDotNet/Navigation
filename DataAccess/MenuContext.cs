namespace Menu;

public class MenuContext : DatabaseContext
{
    public override string ConnectionStringName => "Menu";

    public DbSet<Menu.LinkGroup> LinkGroups { get; set; }

    public DbSet<Menu.Link> Links { get; set; }

    public DbSet<Menu.MenuItem> MenuItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<MenuItem>()
            .Property(p => p.IsDirectory)
            .HasComputedColumnSql("Url is null or trim(Url) != ''");
        base.OnModelCreating(builder);
    }
}
