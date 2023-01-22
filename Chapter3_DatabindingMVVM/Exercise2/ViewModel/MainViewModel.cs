using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Exercise2.ViewModel;

public class MainViewModel : ViewModelBase, IMainViewModel
{
    private readonly ISideBarViewModel _sideBarViewModel;
    private readonly IMovieDetailViewModel _movieDetailViewModel;
    public MainViewModel(ISideBarViewModel sideBarViewModel,
        IMovieDetailViewModel movieDetailViewModel)
    {
        sideBarViewModel.PropertyChanged +=
            (sender, args) => MovieDetailViewModel.Movie = SideBarViewModel.SelectedMovie;
        _sideBarViewModel = sideBarViewModel;
        _movieDetailViewModel = movieDetailViewModel;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public override void Load()
    {
        SideBarViewModel.Load();
    }
    

    public ISideBarViewModel SideBarViewModel => _sideBarViewModel;
    public IMovieDetailViewModel MovieDetailViewModel => _movieDetailViewModel;
}