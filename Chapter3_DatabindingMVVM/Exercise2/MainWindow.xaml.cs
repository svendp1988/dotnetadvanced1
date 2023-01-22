using System.Windows;
using Exercise2.View;
using Exercise2.ViewModel;

namespace Exercise2
{
    public partial class MainWindow : Window
    {
        public MainWindow(IMainViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Load();
            DataContext = viewModel;
            Loaded += (_,_) => viewModel.Load();
        }
    }
}
