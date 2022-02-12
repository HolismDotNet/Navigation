namespace Navigation;

public class LinkController : Controller<Link, Link>
{
    public override ReadBusiness<Link> ReadBusiness => new LinkBusiness();

    public override Business<Link, Link> Business => new LinkBusiness();

    [BindProperty(SupportsGet = true)]
    public long LinkGroupId { get; set; }

    public override Action<ListParameters> ListParametersAugmenter => listParameters => 
    {
        if (LinkGroupId == 0)
        {
            throw new ClientException("LinkGroupId is not provided");
        }
        listParameters.AddFilter<Link>(i => i.LinkGroupId, LinkGroupId);
    };
}