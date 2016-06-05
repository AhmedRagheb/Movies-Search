using System.Collections.Generic;
using Movies.Models;
using Movies.Repository.Cache;
using Movies.Services.Common;
using System.Linq;
using Movies.Contracts;
using Movies.Contracts.RepositoryContracts;
using Movies.Models.RepositoryModel;

namespace Movies.Repository
{
    /// <summary>
    /// Acting as a repository for Movies
    /// </summary>
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IMovieService _moviesService;

        /// <summary>
        /// Constractor, Init the movies service object
        /// </summary>
        /// <param name="unitOfWork">Current Selected Service (TheMovieDB, OmDb, ... )</param>
        public MoviesRepository(IServicesFactory unitOfWork)
        {
            _moviesService = unitOfWork.CreateMovieService();
        }

        /// <summary>
        /// Get List of movies by keyword. check in cache first if not found, invoke service to get data.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public CacheResponse<List<MovieModel>> GetMovies(string keyword)
        {
            return CacheHelper<List<MovieModel>>
                .Get(keyword, () => GetMoviesFromService(keyword));
        }

        /// <summary>
        /// Get Movies from WebServive.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        private List<MovieModel> GetMoviesFromService(string keyword)
        {
            var result = _moviesService.Search(keyword);
            var moviesList = result;

            return moviesList;
        }

        /// <summary>
        /// Get Movie By Id
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="id">Id of movie</param>
        /// <returns></returns>
        public MovieModel GetMovieById(string keyword, string id)
        {
            List<MovieModel> cachedMovies = CacheHelper<List<MovieModel>>
                .Get(keyword, () => GetMoviesFromService(keyword)).Obj;

            var movie = cachedMovies.First(x => x.Id == id);

            return movie;
        }

    }

}
