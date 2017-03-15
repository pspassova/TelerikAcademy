using Movies.Data.Contracts;
using System;
using System.Collections.Generic;
using Movies.Models;

namespace Movies.Data.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IEfRepository<Movie> repository;
        private readonly IUnitOfWork unitOfWork;

        public MoviesService(IEfRepository<Movie> repository, IUnitOfWork unitOfWork)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Movie> GetAll()
        {
            return this.repository.GetAll();
        }

        public void Add(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            this.repository.Add(movie);
            this.unitOfWork.Commit();
        }

        public void Update(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            this.repository.Update(movie);
            this.unitOfWork.Commit();
        }

        public void Remove(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            this.repository.Delete(movie);
            this.unitOfWork.Commit();
        }
    }
}
