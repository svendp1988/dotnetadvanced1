using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise1
{
    public interface IMoviesDataProvider
    {
        IEnumerable<Movie>? GetAll();
    }

    public class MoviesDataProvider : IMoviesDataProvider
    {
        public IEnumerable<Movie>? GetAll()
        {
            return new List<Movie>
            {
                new()
                {
                    Title = "The Godfather",
                    Director = "Francis Ford Coppola",
                    ReleaseYear = 1972
                },
                new()
                {
                    Title = "The Shawshank Redemption",
                    Director = "Frank Darabont",
                    ReleaseYear = 1994
                }
            };
        }
    }
}