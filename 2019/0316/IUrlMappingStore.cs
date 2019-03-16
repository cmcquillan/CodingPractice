namespace ShortUrl
{
    public interface IUrlMappingStore
    {
        UrlMapping GetUrlMapping(string shortSegment);
        UrlMapping SaveUrlMapping(string longUrl);
    }
}