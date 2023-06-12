namespace BlazorSignalR.Client.Repositories
{
    public interface IRepository
    {
        Task<HttpResponseWrapper<object>> Delete<T>(string url);
        Task<HttpResponseWrapper<T>> Get<T>(string url);
        Task<HttpResponseWrapper<object>> Post<T>(string url, T send);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T send);
    }
}
