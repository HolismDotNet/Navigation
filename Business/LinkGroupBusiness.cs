namespace Navigation;

public class LinkGroupBusiness : Business<LinkGroup, LinkGroup>
{
    protected override Read<LinkGroup> Read => Repository.LinkGroup;

    protected override Write<LinkGroup> Write => Repository.LinkGroup;
}