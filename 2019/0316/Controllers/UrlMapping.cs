using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShortUrl
{

    public class UrlMapping
    {
        public string LongUrl { get; set; }

        public string ShortSegment { get; set; }

    }

    public class ShortUrlWrapper : UrlMapping
    {
        public ShortUrlWrapper(HttpContext context, UrlMapping mapping)
        {
            this.LongUrl = mapping.LongUrl;
            this.ShortSegment = mapping.ShortSegment;

            var scheme =  context.Request.Scheme;
            var host = context.Request.Host;
            var url = $"{scheme}://{host}/{mapping.ShortSegment}";
            this.ShortUrl = url;
        }

        public string ShortUrl { get; set; }
    }
}