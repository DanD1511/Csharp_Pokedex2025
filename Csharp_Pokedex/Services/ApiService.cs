using System.Net.Http;
using System.Net.Http.Json;
using Csharp_Pokedex.Domain.Interfaces;

namespace Csharp_Pokedex.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient? _apiClient;


        public ApiService(IApiClient? apiClient)
        {
            _apiClient = apiClient?.InitializeClient(baseUrl: "localhost:8000");
        }

        public async Task<T>? GetAsync<T>(string endpoint) where T : class
        {
            try
            {
                var response = await _apiClient?.GetAsync(endpoint)!;
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error fetching data from API: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred: {ex.Message}", ex);
            }
        }

        public async Task<T>? PostAsync<T>(string endpoint, object? data = null)
        {
            try
            {
                HttpResponseMessage response;
                if (data is null)
                {
                    response = await _apiClient?.PostAsync(endpoint, null)!;
                }
                else
                {
                    response = await _apiClient?.PostAsJsonAsync(endpoint, data)!;
                }

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error posting data to API: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred: {ex.Message}", ex);
            }
        }
    }
}

