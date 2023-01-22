using System.Windows;
using HumanResourcesApp.AppLogic;
using HumanResourcesApp.AppLogic.Contracts;
using HumanResourcesApp.Infrastructure;
using HumanResourcesApp.Presentation.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResourcesApp.Presentation
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<MainWindow>();

            services.AddTransient<MainViewModel>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<PairProgrammingViewModel>();
            services.AddTransient<HumanResourcesContext>();

            services.AddTransient<IEmployeeRepository, EmployeeDbRepository>();
            services.AddTransient<IPairProgrammingService, PairProgrammingService>();
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
