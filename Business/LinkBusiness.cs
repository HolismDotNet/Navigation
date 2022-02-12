namespace Navigation;

public class LinkBusiness : Business<Link, Link>
{
    protected override Read<Link> Read => Repository.Link;

    protected override Write<Link> Write => Repository.Link;
}