using System;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;

namespace ShortUrl
{
    public class UrlMappingStore : IUrlMappingStore
    {
        private readonly ConcurrentDictionary<string, UrlMapping> _store = new ConcurrentDictionary<string, UrlMapping>();
        private readonly HashAlgorithm _sha;
        private readonly Random _random = new Random(DateTime.Now.Millisecond);

        public UrlMappingStore()
        {
            _sha = SHA256.Create();
        }

        public UrlMapping SaveUrlMapping(string longUrl)
        {
            var bytes = Encoding.UTF8.GetBytes($"{_random.NextDouble()}{longUrl}");
            var hashBytes = _sha.ComputeHash(bytes);

            StringBuilder str = new StringBuilder();

            foreach (var item in hashBytes)
                str.AppendFormat("{0:x2}", item);

            var mapping = new UrlMapping
            {
                LongUrl = longUrl,
                ShortSegment = str.ToString().Substring(0, 8),
            };

            _store.TryAdd(mapping.ShortSegment, mapping);

            return mapping;
     
        }

        public UrlMapping GetUrlMapping(string shortSegment)
        {
            _store.TryGetValue(shortSegment, out UrlMapping mapping);
            return mapping;
        }
    }
}