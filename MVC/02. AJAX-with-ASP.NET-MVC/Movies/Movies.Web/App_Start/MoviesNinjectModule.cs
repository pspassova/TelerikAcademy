using Movies.Data;
using Movies.Data.Contracts;
using Movies.Data.Services;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Movies.Web.App_Start
{
    public class MoviesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMoviesDbContext>().To<MoviesDbContext>().InRequestScope();
            this.Bind(typeof(IEfRepository<>)).To(typeof(EfRepository<>));
            this.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            this.Bind<IMoviesService>().To<MoviesService>();
        }
    }
}