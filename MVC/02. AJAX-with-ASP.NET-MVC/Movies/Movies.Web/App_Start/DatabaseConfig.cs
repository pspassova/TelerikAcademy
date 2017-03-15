using Movies.Data;
using System.Data.Entity;

namespace Movies.Web.App_Start
{
    public class DatabaseConfig
    {
        public static void InitializeDatabase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesDbContext, Movies.Data.Migrations.Configuration>());
            MoviesDbContext.Create().InitializeDatabase();
        }
    }
}