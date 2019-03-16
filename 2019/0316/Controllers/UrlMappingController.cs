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
    public ActionResult<ShortUrlWrapper> AddNewUrlMapping([FromBody] ShortenRequest request)
    {
        var mapping = _store.SaveUrlMapping(request.LongUrl);
        return new ShortUrlWrapper(HttpContext, mapping);
    }
}