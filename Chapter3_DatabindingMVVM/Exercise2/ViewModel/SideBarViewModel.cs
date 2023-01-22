using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Exercise2.Command;
using Exercise2.Data;
using Exercise2.Model;

namespace Exercise2.ViewModel;

public class SideBarViewModel : ViewModelBase, ISideBarViewModel
{
    private readonly IMovieRepository _movieRepository;
    private IList<Movie>? _movies;
    private Movie? _selectedMovie;

    public SideBarViewModel(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
        Movies = new List<Movie>();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    

    public override void Load()
    {
        Movies = _movieRepository.GetAll();
    }

    public IList<Movie> Movies
    {
        get => _movies;
        private set
        {
            _movies = value;
            OnPropertyChanged();
        }
    }

    public Movie? SelectedMovie
    {
        get => _selectedMovie;
        set
        {
            _selectedMovie = value;
            OnPropertyChanged();
        }
    }
}