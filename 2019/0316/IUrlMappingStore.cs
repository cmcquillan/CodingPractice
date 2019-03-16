namespace ShortUrl
{
    public interface IUrlMappingStore
    {
        UrlMapping SaveUrlMapping(string longUrl);
    }
}