namespace Navigation;

public class LinkGroupBusiness : Business<LinkGroup, LinkGroup>
{
    protected override Read<LinkGroup> Read => Repository.LinkGroup;

    protected override Write<LinkGroup> Write => Repository.LinkGroup;

    public override LinkGroup GetByKey(string key)
    {
        var linkGroup = base.GetByKey(key);
        if (linkGroup == null)
        {
            return null;
        }
        linkGroup.RelatedItems.Links = new LinkBusiness().GetLinks(linkGroup.Id);
        return linkGroup;
    }

    public List<dynamic> GetAllLinkGroups()
    {
        List<string> keys = (List<string>)Cache.Get("LinkGroupKeys");
        if (keys == null)
        {
            keys = GetKeys();
        }
        var linkGroups = GetByKeys(keys.ToArray());
        return linkGroups;
    }

    public List<dynamic> GetByKeys(params string[] keys)
    {
        var linkGroups = new List<dynamic>();
        foreach (var key in keys)
        {
            var linkGroup = Cache.Get(key);
            if (linkGroup != null)
            {
                linkGroups.Add(linkGroup);
            }
            else
            {
                Logger.LogWarning($"LinkGroup {key} is not cached. It might not exist in the database");
                var dbLinkGroup = GetByKey(key);
                if (dbLinkGroup != null)
                {
                    linkGroups.Add(dbLinkGroup);
                }
            }
        }
        return linkGroups;
    }

    public Dictionary<string, dynamic> LoadCache()
    {
        var keys = GetKeys();
        var linkGroups = new List<LinkGroup>();
        foreach (var key in keys)
        {
            var linkGroup = GetByKey(key);
            if (linkGroup != null)
            {
                linkGroups.Add(linkGroup);
            }
        }
        var result = linkGroups.ToDictionary(i => i.Key, i => Minify(i));
        result.Add("AllLinkGroupKeys", keys);
        return result;
    }

    public object Minify(LinkGroup linkGroup)
    {
        dynamic minified = new ExpandoObject();
        minified.Id = linkGroup.Id;
        minified.Key = linkGroup.Key;
        minified.Title = linkGroup.Title;
        minified.Links = MinfiyLinks(linkGroup.RelatedItems.Links);
        return minified;
    }

    private dynamic MinfiyLinks(List<Link> links)
    {
        var minifieds = new List<dynamic>();
        foreach (var link in links)
        {
            dynamic minified = new ExpandoObject();
            minified.Id = link.Id;
            minified.Text = link.Text;
            minified.Url = link.Url;
            minifieds.Add(minified);
        }
        return minifieds;
    }
}