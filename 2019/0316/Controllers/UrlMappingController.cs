using Microsoft.AspNetCore.Mvc;
using ShortUrl;

[Route("add-new")]
public class UrlMappingController : Controller
{
    private readonly IUrlMappingStore _store;

    public UrlMappingController(IUrlMappingStore store)
    {
        this._store = store;
    }

    [HttpPost("")]
    public ActionResult<UrlMapping> AddNewUrlMapping([FromBody] ShortenRequest request)
    {
        return new UrlMapping {
            ShortUrl = request.LongUrl,
            LongUrl = request.LongUrl,
        };
    }
}