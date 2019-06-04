using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApiReaderMT.DataAccess
{
    /// <summary>
    /// Interact with a Web API service
    /// </summary>
    internal class WebApiClient
    {
        private HttpClient _httpClient;

        private Uri BaseEndpoint { get; set; }

        public WebApiClient(Uri baseEndpoint)
        {
            if (baseEndpoint == null)
            {
                throw new ArgumentNullException("baseEndpoint");
            }
            BaseEndpoint = baseEndpoint;
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Call the Web API and deserialize the resulting JSON into an object of type T
        /// </summary>
        public async Task<T> Get<T>(string requestPath)
        {
            var endpoint = new Uri(BaseEndpoint, requestPath);
            var response = await _httpClient.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
