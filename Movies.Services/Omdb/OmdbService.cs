using System;
using System.Collections.Generic;
using Movies.Contracts;
using Movies.Contracts.ServicesContracts;
using Movies.Models;
using Movies.Models.RepositoryModel;
using Movies.Models.ServicesModels;
using Movies.Services.Common;
using RestSharp;

namespace Movies.Services.Omdb
{
    public class OmdbService : IMovieService
    {
        public readonly IOmdbServiceConfiguration _configurationFactory;
        public readonly RestClient _client;

        /// <summary>
        /// Init Configuration Object and Restful client
        /// </summary>
        /// <param name="configurationFactory"></param>
        public OmdbService(IConfigurationsFactory configurationFactory)
        {
            _configurationFactory = configurationFactory.CreateOmdbServiceConfiguration();
            _client = new RestClient(_configurationFactory.BaseAddress);
        }


        /// <summary>
        /// Search in Omdb WebService for movies
        /// </summary>
        /// <param name="keyword">Movie name</param>
        /// <returns>List of movies matched search criteria</returns>
        public List<MovieModel> Search(string keyword)
        {
            try
            {
                var request = new RestRequest(Method.GET);
                request.AddParameter("t", keyword);
                request.AddParameter("plot", "short");
                request.AddParameter("r", "json");

                var response = _client.Execute<OmdbModel>(request);
                var data = response.Data;
                var movieModels = new List<MovieModel>
                                      {
                                          new MovieModel
                                              {
                                                  Description = data.Plot,
                                                  PosterUrl = data.Poster,
                                                  ReleaseDate = data.Released,
                                                  Title = data.Title,
                                                  Vote = data.imdbRating,
                                                  Id = data.Id,
                                                  ReleaseYear = data.Year
                                              }
                                      };

                return movieModels;
            }
            catch (Exception)
            {
                // Should Log Exception Here
                return new List<MovieModel>();
            }
        }
    }
}
