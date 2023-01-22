using System.ComponentModel;
using System.Runtime.CompilerServices;
using Exercise2.Command;
using Exercise2.Model;

namespace Exercise2.ViewModel;

public class MovieDetailViewModel : ViewModelBase, IMovieDetailViewModel
{
    private Movie? _movie;

    public MovieDetailViewModel()
    {
        GiveFiveStarRatingCommand = new DelegateCommand(GiveFiveStarRating, CanGiveFiveStarRating);
    }
    
    public event PropertyChangedEventHandler PropertyChanged;

    // This method is called by the Set accessor of each property.
    // The CallerMemberName attribute that is applied to the optional propertyName
    // parameter causes the property name of the caller to be substituted as an argument.
    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public override void Load()
    {
       
    }

    public DelegateCommand GiveFiveStarRatingCommand { get; }

    private void GiveFiveStarRating(object? parameter)
    {
        Movie.Rating = 5;
        GiveFiveStarRatingCommand.RaiseCanExecuteChanged();
    }

    private bool CanGiveFiveStarRating(object? parameter) => !HasNoMovie && Movie.Rating != 5;

    public Movie? Movie
    {
        set
        {
            switch (HasNoMovie)
            {
                case true when null != value:
                    _movie = value;
                    _movie.PropertyChanged += (_, _) => GiveFiveStarRatingCommand.RaiseCanExecuteChanged();
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("HasNoMovie");
                    GiveFiveStarRatingCommand.RaiseCanExecuteChanged();
                    break;
                case false when null == value:
                    _movie = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("HasNoMovie");
                    GiveFiveStarRatingCommand.RaiseCanExecuteChanged();
                    break;
                default:
                {
                    if (_movie != value)
                    {
                        _movie = value;
                        _movie.PropertyChanged += (_, _) => GiveFiveStarRatingCommand.RaiseCanExecuteChanged();
                        NotifyPropertyChanged();
                        GiveFiveStarRatingCommand.RaiseCanExecuteChanged();
                    }

                    break;
                }
            }
        }
        get => _movie;
    }
    
    public bool HasNoMovie => _movie == null;
}

