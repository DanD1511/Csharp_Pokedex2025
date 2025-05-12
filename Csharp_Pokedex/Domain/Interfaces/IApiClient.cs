using System.Net.Http;

namespace Csharp_Pokedex.Domain.Interfaces
{
    public interface IApiClient
    {
        HttpClient InitializeClient(string baseUrl);
    }
}
