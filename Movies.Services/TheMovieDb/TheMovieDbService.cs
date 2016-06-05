using System;
using System.Collections.Generic;
using Movies.Contracts;
using Movies.Models;
using Movies.Models.RepositoryModel;
using Movies.Models.ServicesModels;
using RestSharp;

namespace Movies.Services.TheMovieDb
{
    public class TheMovieDbService : IMovieService
    {
        public readonly ITheMovieDbConfiguration _configurationFactory;
        public readonly RestClient _client;

        /// <summary>
        /// Init Configuration Object and Restful client
        /// </summary>
        /// <param name="configurationFactory"></param>
        public TheMovieDbService(IConfigurationsFactory configurationFactory)
        {
            _configurationFactory = configurationFactory.CreateMovieDbConfiguration();
            _client = new RestClient(_configurationFactory.BaseAddress);
        }

        /// <summary>
        /// Search in TheMovieDb WebService for movies
        /// </summary>
        /// <param name="keyword">Movie name</param>
        /// <returns>List of movies matched search criteria</returns>
        public List<MovieModel> Search(string keyword)
        {
            try
            {
                var request = new RestRequest("search/movie", Method.GET);
                request.AddParameter("api_key", _configurationFactory.ApiKey);
                request.AddParameter("query", keyword);
                request.AddParameter("page", "1");

                var response = _client.Execute<TheMoviesDbSearchResultsModel>(request);
                var results = response.Data.results;
                var movies = new List<MovieModel>();
                foreach (var movie in results)
                {
                    var newmovie = new MovieModel
                                   {
                                       Id = movie.id.ToString(),
                                       Description = movie.overview,
                                       Title = movie.title,
                                       PosterUrl = "https://image.tmdb.org/t/p/w300/" + movie.poster_path,
                                       Vote = movie.vote_average,
                                       ReleaseDate = movie.release_date
                                   };
                    DateTime date;
                    var valid = DateTime.TryParse(movie.release_date, out date);
                    newmovie.ReleaseYear = valid ? date.Year : 0;

                    movies.Add(newmovie);
                }

                return movies;
            }
            catch (Exception)
            {
                // Should Log Here Using Elmah or anyservice and save log in DB
                // For Testing will return Empty list
                return new List<MovieModel>();
            }
            
        } 
    }
}
