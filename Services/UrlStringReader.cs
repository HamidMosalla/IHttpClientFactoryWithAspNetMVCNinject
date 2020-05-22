using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IHttpFactoryWithAspNetMVCNinject.Services
{
    public class UrlStringReader
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UrlStringReader(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetJsonAsyncIncorrectUsage(Uri uri)
        {
            using (var client = new HttpClient())
            {
                // use ConfigureAwait(false) whenever the rest of that async method does not depend on the current context.
                // https://stackoverflow.com/a/40220190/1650277
                return await client.GetStringAsync(uri).ConfigureAwait(false);
            }
        }

        public async Task<string> GetJsonAsyncCorrectUsage(Uri uri)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                // use ConfigureAwait(false) whenever the rest of that async method does not depend on the current context.
                // https://stackoverflow.com/a/40220190/1650277
                return await client.GetStringAsync(uri).ConfigureAwait(false);
            }
        }
    }
}
