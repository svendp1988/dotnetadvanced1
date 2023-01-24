using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using ShoppingListApp.Business.Contracts;
using ShoppingListApp.Data;

namespace ShoppingListApp.Presentation
{
    public partial class App : Application
    {
        // private readonly ServiceProvider _serviceProvider;
        //
        // public App()
        // {
        //     ServiceCollection services = new();
        //     ConfigureServices(services);
        //     _serviceProvider = services.BuildServiceProvider();
        // }
        //
        // private void ConfigureServices(ServiceCollection services)
        // {
        //     services.AddTransient<MainWindow>();
        //     
        // }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow window = new MainWindow(new ShoppingListDbRepository());
            window.Show();
        }
    }
}
