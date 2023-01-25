using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Skeleton.Presentation
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
       

        public MainWindow()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}