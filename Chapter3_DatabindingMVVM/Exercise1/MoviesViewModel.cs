using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise1.ViewModel
{
    public class MoviesViewModel
    {
        private readonly IMoviesDataProvider _dataProvider;
        public ObservableCollection<Movie> Movies { get; } = new();

        public MoviesViewModel(IMoviesDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void Load()
        {
            if (Movies.Any()) return;
            var movies = _dataProvider.GetAll();
            if (movies is not null)
            {
                foreach (var movie in movies)
                {
                    Movies.Add(movie);
                }
            }
        }

        internal void Add(Movie movie)
        {
            Movies.Add(movie);
        }
    }
}