using DartApp.AppLogic;
using DartApp.AppLogic.Contracts;
using DartApp.Infrastructure.Storage;

using System;
using System.IO;
using System.Windows;

namespace DartApp.Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IPlayerRepository playerRepository = new PlayerFileRepository(Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "DartApp"));
            IPlayerService playerService = new PlayerService(playerRepository);
            MainWindow window = new MainWindow(playerService);
            window.Show();
            // TODO: Wiring and show MainWindow.
        }
    }
}
