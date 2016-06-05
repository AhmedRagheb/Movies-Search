using System;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.Contracts;
using Movies.Services.Omdb;
using Movies.Services.TheMovieDb;
using RestSharp;

namespace Movies.Tests.Services
{
    [TestClass]
    public class OmdbServiceTest
    {
        private IConfigurationsFactory _configurationsFactory;
        private OmdbService _omdbService;

        [TestInitialize]
        public void Initialize()
        {
            StructureMapConfigureTest.Initialize();
            _configurationsFactory = StructureMapConfigureTest.Container.GetInstance<IConfigurationsFactory>();

            _omdbService = new OmdbService(_configurationsFactory);
        }

        [TestMethod]
        public void TestOmdbServiceServiceIsUpAndRetuenData()
        {
            var request = new RestRequest(Method.GET);

            var response = _omdbService._client.Execute(request);
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }


        [TestMethod]
        public void TestOmdbServiceServiceSearch()
        {
            var movies = _omdbService.Search("Braveheart");
            Assert.IsTrue(movies.Count > 0);
        }

        [TestMethod]
        public void TestOmdbServiceServiceSearchIsReturnRelevantData()
        {
            const string searchQuery = "the revenant";
            var movies = _omdbService.Search(searchQuery);
            var movieTitle = movies.First().Title;
            Assert.IsTrue(movieTitle.ToLower().Contains(searchQuery));
        }

        /// <summary>
        /// Test movie release year as we depend on it in searching on youtube.
        /// </summary>
        [TestMethod]
        public void TestOmdbServiceValidateMovieReleaseYear()
        {
            const string searchQuery = "Bridge of Spies";
            var movies = _omdbService.Search(searchQuery);
            var releaseYear = movies.First().ReleaseYear;
            Assert.AreEqual(releaseYear, 2015);
        }
    }
}
