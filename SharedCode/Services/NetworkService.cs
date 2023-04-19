using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SharedCode.Services
{
    public interface INetworkService
    {
        Task<T> GetData<T>(string endpoint);
    }

    public class NetworkService : INetworkService
    {
        private static HttpClient httpClient = new HttpClient();

        public async Task<T> GetData<T>(string endpoint)
        {
            var response = new HttpResponseMessage();
            try
            {
                response = await httpClient.GetAsync(endpoint);
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

