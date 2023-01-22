using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Exercise1.ViewModel;

namespace Exercise1
{
    public partial class MainWindow : Window
    {
        private readonly MoviesViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MoviesViewModel(new MoviesDataProvider());
            DataContext = _viewModel;
            NewMovieGroupBox.DataContext = new Movie();
            _viewModel.Load();
        }

        private void AddNewMovieButton_OnClick(object sender, RoutedEventArgs e)
        {
            var movie = AddNewMovieButton.DataContext as Movie;
            if (MovieIsValid(movie))
            {
                _viewModel.Add(movie);
                NewMovieGroupBox.DataContext = new Movie();
                ErrorMessageTextBlock.Text = string.Empty;
            }
        }

        private bool MovieIsValid(Movie? movie)
        {
            if (movie is null)
            {
                return false;
            }
            if (movie.Title.ToLower().Equals("unknown"))
            {
                ErrorMessageTextBlock.Text = "Movie with an 'Unknown' title cannot be added.";
                return false;
            }

            if (movie.Director.ToLower().Equals("unknown"))
            {
                ErrorMessageTextBlock.Text = "Movie with an 'Unknown' director cannot be added.";
                return false;
            }

            if (movie.ReleaseYear <= Decimal.Zero)
            {
                ErrorMessageTextBlock.Text = "Movie with a release year smaller then or equal to 0 cannot be added.";
                return false;
            }

            return true;
        }
    }
}
