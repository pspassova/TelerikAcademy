using Movies.Data.Contracts;
using Movies.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Movies.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMoviesService moviesService;

        public HomeController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Movie> movies = this.moviesService.GetAll();

            return View(movies);
        }

        [HttpGet]
        public ActionResult AddMovie()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult AddMovie(Movie movie)
        {
            this.moviesService.Add(movie);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditMovie()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult EditMovie(Movie movie)
        {
            this.moviesService.Update(movie);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult RemoveMovie()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult RemoveMovie(Movie movie)
        {
            this.moviesService.Remove(movie);

            return RedirectToAction("Index");
        }
    }
}