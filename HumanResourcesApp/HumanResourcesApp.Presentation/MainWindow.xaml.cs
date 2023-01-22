using System.Windows;
using HumanResourcesApp.Infrastructure;
using HumanResourcesApp.Presentation.ViewModel;

namespace HumanResourcesApp.Presentation
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();

            _viewModel = mainViewModel;
            Loaded += MainWindow_Loaded;
            DataContext = _viewModel;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Load();
        }
    }
}