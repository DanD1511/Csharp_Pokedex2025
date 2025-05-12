namespace Csharp_Pokedex.Domain.Interfaces
{
    public interface IApiService
    {
        Task<T>? GetAsync<T>(string endpoint) where T : class;
        Task<T>? PostAsync<T>(string endpoint, object? data);
    }
}
