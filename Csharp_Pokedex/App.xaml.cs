using System.Windows;
using Csharp_Pokedex.Domain.Interfaces;
using Csharp_Pokedex.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Csharp_Pokedex
{
    public partial class App : Application
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IApiClient, ApiClient>();
            services.AddSingleton<IApiService, ApiService>();

            services.AddTransient<MainWindow>();
        }
    }
}
