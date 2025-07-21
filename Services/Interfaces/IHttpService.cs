namespace Btc.App.Services.Interfaces
{
    public interface IHttpService
    {
        Task<bool> GetAsync(string uri);
        Task<T?> GetAsync<T>(string uri) where T : class;
        Task<T?> GetAsync<T>(string uri, Dictionary<string, string> queryParams) where T : class;
        Task<bool> PostAsync<T>(string uri, T body) where T : class;
    }
}
