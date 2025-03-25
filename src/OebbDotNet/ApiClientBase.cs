using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OebbDotNet
{
    public abstract class ApiClientBase : IDisposable
    {
        private HttpClient _httpClient;
        private JsonSerializerOptions _serializerOptions;

        public ApiClientBase(string baseAddress)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseAddress);

            _serializerOptions = new JsonSerializerOptions();
            _serializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        }

        protected async Task<TResponse> GetAsync<TResponse>(string url, string accessToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            if (accessToken != null)
                request.Headers.Add("AccessToken", accessToken);
            request.Headers.Add("Host", "shop.oebbtickets.at");

            var response = await _httpClient.SendAsync(request);
            string responseContent = await response.Content.ReadAsStringAsync();
            return DeserializeObject<TResponse>(responseContent);
        }

        protected async Task<TResponse> PostAsync<TRequest, TResponse>(string url, string accessToken, TRequest payload)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (accessToken != null)
                request.Headers.Add("AccessToken", accessToken);
            request.Headers.Add("Host", "shop.oebbtickets.at");

            string content = SerializeObject(payload);
            request.Content = JsonContent.Create(payload);

            var response = await _httpClient.SendAsync(request);
            string responseContent = await response.Content.ReadAsStringAsync();
            return DeserializeObject<TResponse>(responseContent);
        }

        protected string SerializeObject<T>(T data)
        {
            return JsonSerializer.Serialize(data, _serializerOptions);
        }

        protected T DeserializeObject<T>(string data)
        {
            return JsonSerializer.Deserialize<T>(data, _serializerOptions);
        }

        protected HttpClient HttpClient => _httpClient;

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
