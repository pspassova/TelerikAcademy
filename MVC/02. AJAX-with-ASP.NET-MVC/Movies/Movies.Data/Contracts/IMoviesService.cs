using Movies.Models;
using System.Collections.Generic;

namespace Movies.Data.Contracts
{
    public interface IMoviesService
    {
        IEnumerable<Movie> GetAll();

        void Add(Movie movie);

        void Update(Movie movie);

        void Remove(Movie movie);
    }
}
