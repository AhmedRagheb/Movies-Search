using System.Collections.Generic;
using Movies.Models;
using Movies.Models.RepositoryModel;

namespace Movies.Contracts
{
    /// <summary>
    /// Public Interface any movie database should implement
    /// </summary>
    public interface IMovieService
    {
        List<MovieModel> Search(string keyword);
    }
}