using System;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.Contracts;
using Movies.Services.Common;
using Movies.Services.TheMovieDb;
using RestSharp;

namespace Movies.Tests.Services
{
    [TestClass]
    public class TheMoviesDbServiceTest
    {
        private IConfigurationsFactory _configurationsFactory;
        private TheMovieDbService _theMovieDbService;

        [TestInitialize]
        public void Initialize()
        {
            StructureMapConfigureTest.Initialize();
            _configurationsFactory = StructureMapConfigureTest.Container.GetInstance<IConfigurationsFactory>();

            _theMovieDbService = new TheMovieDbService(_configurationsFactory);
        }

        [TestMethod]
        public void TestTheMoviesDbServiceIsUpAndRetuenData()
        {
            var request = new RestRequest("search/movie", Method.GET);
            request.AddParameter("api_key", _theMovieDbService._configurationFactory.ApiKey);
            request.AddParameter("query", "Braveheart");

            var response = _theMovieDbService._client.Execute(request);
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }


        [TestMethod]
        public void TestTheMoviesDbServiceSearch()
        {
            var movies = _theMovieDbService.Search("Braveheart");
            Assert.IsTrue(movies.Count > 0);
        }

        [TestMethod]
        public void TestTheMoviesDbServiceSearchIsReturnRelevantData()
        {
            const string searchQuery = "the revenant";
            var movies = _theMovieDbService.Search(searchQuery);
            var movieTitle = movies.First().Title;
            Assert.IsTrue(movieTitle.ToLower().Contains(searchQuery));
        }

        /// <summary>
        /// Test movie release year as we depend on it in searching on youtube.
        /// </summary>
        [TestMethod]
        public void TestTheMoviesDbValidateMovieReleaseYear()
        {
            const string searchQuery = "Bridge of Spies";
            var movies = _theMovieDbService.Search(searchQuery);
            var releaseYear = movies.First().ReleaseYear;
            Assert.AreEqual(releaseYear, 2015);
        }
    }
}
