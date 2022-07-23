namespace Navigation;

public class LinkBusiness : Business<Link, Link>
{
    protected override Read<Link> Read => Repository.Link;

    protected override Write<Link> Write => Repository.Link;

    public List<Link> GetLinks(long linkGroupId)
    {
        var links = GetList(i => i.LinkGroupId == linkGroupId);
        return links;
    }
}