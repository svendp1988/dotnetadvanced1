using System.Windows;
using Microsoft.Extensions.DependencyInjection;
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
            // base.OnStartup(e);

            // var mainWindow = _serviceProvider.GetService<MainWindow>();
            // mainWindow?.Show();
            
            //TODO: create an instance of a class that implements IShoppingListRepository
            //TODO: create an instance of MainWindow
            //TODO: show the instance of MainWindow
        }
    }
}
