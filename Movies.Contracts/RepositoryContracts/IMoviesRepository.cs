using System.Collections.Generic;
using Movies.Models;
using Movies.Models.RepositoryModel;

namespace Movies.Contracts.RepositoryContracts
{
    /// <summary>
    /// The Repository interface
    /// </summary>
    public interface IMoviesRepository
    {
        CacheResponse<List<MovieModel>> GetMovies(string keywork);
        MovieModel GetMovieById(string keyword, string id);
    }
}
