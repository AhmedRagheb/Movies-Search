using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Movies.Contracts.RepositoryContracts;
using Movies.Models;
using Movies.Models.RepositoryModel;
using Movies.Repository;
using Movies.Repository.Cache;

namespace Movies.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly ITrailerRepository _trailerRepository;

        public HomeController()
        {
            _moviesRepository = StructureMapConfigure.Container.GetInstance<IMoviesRepository>();
            _trailerRepository = StructureMapConfigure.Container.GetInstance<ITrailerRepository>();
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get Movies From Cache or Service.
        /// </summary>
        /// <param name="tags">search term</param>
        /// <returns>List of Movies rendered as HTML</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetMovies(string tags)
        {
            tags = tags.Trim();
            CacheResponse<List<MovieModel>> movies = _moviesRepository.GetMovies(tags);
            ViewBag.MoviesSource = movies.IsLoadedFromCache ? "Loaded from cache" : "Loaded from Service";
            return PartialView("_Movies", movies.Obj);
        }

        /// <summary>
        /// Get Movie and its Embeded Trailer 
        /// </summary>
        /// <param name="tags">search term</param>
        /// <param name="id">Id of movie</param>
        /// <returns>MOvie Item rendered as HTML</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetMovie(string tags, string id)
        {
            tags = tags.Trim();
            var movie = _moviesRepository.GetMovieById(tags, id);

            var seachMovieNameFormat = "{0} {1} movie trailer";
            movie.EmbededTrailer = _trailerRepository.GetTrailer(string.Format(seachMovieNameFormat, movie.Title, movie.ReleaseYear));
            return PartialView("_MovieDetails", movie);
        }
    }
}