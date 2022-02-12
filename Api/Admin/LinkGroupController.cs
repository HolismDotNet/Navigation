namespace Navigation;

public class LinkGroupController : ReadController<LinkGroup>
{
    public override ReadBusiness<LinkGroup> ReadBusiness => new LinkGroupBusiness();
}