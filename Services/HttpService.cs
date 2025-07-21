using Btc.App.Services.Interfaces;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Web;

namespace Btc.App.Services
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> GetAsync(string uri)
        {
            if (string.IsNullOrWhiteSpace(uri)) throw new ArgumentNullException(nameof(uri));

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(uri);

            if (!response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.NotFound) return false;

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var parsedContent = JsonConvert.DeserializeObject<bool>(content);

            return parsedContent;
        }

        public async Task<T?> GetAsync<T>(string uri) where T : class
        {
            if (string.IsNullOrWhiteSpace(uri)) throw new ArgumentNullException(nameof(uri));

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(uri);

            if (!response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.NotFound) return null;
            //if (!response.IsSuccessStatusCode) // log error

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var parsedContent = JsonConvert.DeserializeObject<T>(content);

            return parsedContent;
        }

        public async Task<T?> GetAsync<T>(string uri, Dictionary<string, string> queryParams) where T : class
        {
            if (string.IsNullOrWhiteSpace(uri)) throw new ArgumentNullException(nameof(uri));

            if (queryParams == null)
            {
                //log warning
                return await GetAsync<T>(uri);
            }

            var query = GetQuery(queryParams);

            return await GetAsync<T>($"{uri}?{query}");
        }

        public async Task<bool> PostAsync<T>(string uri, T body) where T : class
        {
            if (string.IsNullOrWhiteSpace(uri)) throw new ArgumentNullException(nameof(uri));
            if (body == null) throw new ArgumentNullException(nameof(body));

            var client = _httpClientFactory.CreateClient();

            var jsonBody = JsonConvert.SerializeObject(body);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, content);
            return response.IsSuccessStatusCode;
        }

        private string GetQuery(Dictionary<string, string> queryParams)
        {
            if (queryParams == null)
            {
                //log warning
                return string.Empty;
            }

            var query = string.Join(
                "&",
                queryParams.Select(
                    kvp => $"{HttpUtility.UrlEncode(kvp.Key)}={HttpUtility.UrlEncode(kvp.Value)}"
                )
            );

            return query;
        }
    }
}
