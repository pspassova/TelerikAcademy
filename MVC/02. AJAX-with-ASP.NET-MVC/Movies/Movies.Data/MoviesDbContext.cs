using Movies.Data.Contracts;
using System.Data.Entity;
using Movies.Models;

namespace Movies.Data
{
    public class MoviesDbContext : DbContext, IMoviesDbContext
    {
        public MoviesDbContext()
            : base("Movies")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MoviesDbContext>());
        }

        public IDbSet<Movie> Movies
        {
            get;
            set;
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChangesAsync()
        {
            base.SaveChangesAsync();
        }

        public static MoviesDbContext Create()
        {
            return new MoviesDbContext();
        }

        public void InitializeDatabase()
        {
            //this.Movies.AddOrUpdate(new Movie
            //{
            //    Title = "Initial"
            //});
            //this.SaveChanges();
        }
    }
}
