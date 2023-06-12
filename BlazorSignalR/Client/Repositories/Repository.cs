using System.Text;
using System.Text.Json;

namespace BlazorSignalR.Client.Repositories
{
    public class Repository : IRepository
    {
        private readonly HttpClient httpClient;

        public Repository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        private JsonSerializerOptions options => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };


        public async Task<HttpResponseWrapper<T>> Get<T>(string url)
        {
            var responseHttp = await httpClient.GetAsync(url);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await DeserializeResponse<T>(responseHttp, options);
                return new HttpResponseWrapper<T>(response, false, responseHttp);
            }

            return new HttpResponseWrapper<T>(default, true, responseHttp);
        }

        public async Task<HttpResponseWrapper<object>> Delete<T>(string url)
        {
            var responseHttp = await httpClient.DeleteAsync(url);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T send)
        {
            var sendJson = JsonSerializer.Serialize(send);
            var sendContent = new StringContent(sendJson, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync(url, sendContent);

            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);

        }

        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T send)
        {
            var sendJson = JsonSerializer.Serialize(send);
            var sendContent = new StringContent(sendJson, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync(url, sendContent);

            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await DeserializeResponse<TResponse>(responseHttp, options);
                return new HttpResponseWrapper<TResponse>(response, false, responseHttp);
            }

            return new HttpResponseWrapper<TResponse>(default, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        private async Task<T> DeserializeResponse<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, options);
        }
    }
}
