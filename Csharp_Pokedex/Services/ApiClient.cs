using System.Net.Http;
using Csharp_Pokedex.Domain.Interfaces;

namespace Csharp_Pokedex.Services
{
    public class ApiClient : IApiClient
    {
        public HttpClient InitializeClient(string baseUrl)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            return client;
        }
    }
}
