﻿using Movies.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Movies.Data.Contracts
{
    public interface IMoviesDbContext
    {
        IDbSet<Movie> Movies
        {
            get; set;
        }

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        IDbSet<T> Set<T>() where T : class;

        void SaveChangesAsync();

        void InitializeDatabase();
    }
}
