using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HumanResourcesApp.Domain
{
    public class ProgrammingPair : INotifyPropertyChanged
    {
        public Employee Driver { get; set; }
        public Employee Navigator { get; set; }

        public ProgrammingPair(Employee driver, Employee navigator)
        {
            Driver = driver;
            Navigator = navigator;
        }

        public void Switch()
        {
            Employee driver = Driver;
            Driver = Navigator;
            Navigator = driver;
            OnPropertyChanged(nameof(Driver));
            OnPropertyChanged(nameof(Navigator));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}