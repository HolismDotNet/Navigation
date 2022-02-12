namespace Navigation;

public class LinkGroupController : Controller<LinkGroup, LinkGroup>
{
    public override ReadBusiness<LinkGroup> ReadBusiness => new LinkGroupBusiness();

    public override Business<LinkGroup, LinkGroup> Business => new LinkGroupBusiness();
}