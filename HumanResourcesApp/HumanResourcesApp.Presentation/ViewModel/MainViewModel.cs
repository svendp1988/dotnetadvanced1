using HumanResourcesApp.Presentation.Command;

namespace HumanResourcesApp.Presentation.ViewModel;

public class MainViewModel : ViewModelBase
{
    public PairProgrammingViewModel PairProgrammingViewModel { get; }
    public HomeViewModel HomeViewModel { get; }
    private ViewModelBase _selectedViewModel;

    public ViewModelBase SelectedViewModel
    {
        get => _selectedViewModel;
        private set
        {
            _selectedViewModel = value;
            _selectedViewModel.Load();
            OnPropertyChanged();
        }
    }

    public DelegateCommand SelectViewModelCommand { get; }

    public MainViewModel(HomeViewModel homeViewModel, PairProgrammingViewModel
        pairProgrammingViewModel)
    {
        HomeViewModel = homeViewModel;
        PairProgrammingViewModel = pairProgrammingViewModel;
        SelectViewModelCommand = new DelegateCommand(SelectViewModel);
        SelectedViewModel = HomeViewModel;
    }

    private void SelectViewModel(object? obj)
    {
        ViewModelBase viewModel = (ViewModelBase) obj!;
        SelectedViewModel = viewModel;
    }

    public override void Load()
    {
        SelectedViewModel.Load();
    }
}