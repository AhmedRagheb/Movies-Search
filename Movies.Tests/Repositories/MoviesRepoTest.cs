using System;
using System.Linq;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.Contracts;
using Movies.Repository;
using Movies.Services.Omdb;

namespace Movies.Tests.Repositories
{
    [TestClass]
    public class MoviesRepoTest
    {
        private IServicesFactory _servicesFactory;
        private MoviesRepository _moviesRepository;

        [TestInitialize]
        public void Initialize()
        {
            StructureMapConfigureTest.Initialize();
            _servicesFactory = StructureMapConfigureTest.Container.GetInstance<IServicesFactory>();
            HttpContext.Current = new HttpContext(new HttpRequest(null, "http://tempuri.org", null),
                new HttpResponse(null));

            _moviesRepository = new MoviesRepository(_servicesFactory);
        }

        [TestMethod]
        public void TestMoviesRepoGetMoviesIsReturnData()
        {
            var moviesResponse = _moviesRepository.GetMovies("Braveheart");
            var listofMovies = moviesResponse.Obj;

            Assert.IsTrue(listofMovies.Count > 0);
        }

        [TestMethod]
        public void TestMoviesRepoGetMoviesFromService()
        {
            var moviesResponse = _moviesRepository.GetMovies("Braveheart");
            var isLoadedFromService = ! moviesResponse.IsLoadedFromCache;

            Assert.IsTrue(isLoadedFromService);
        }
        
        [TestMethod]
        public void TestMoviesRepoGetMoviesFromServiceReturnRelevantData()
        {
            const string searchQuery = "the revenant";
            var moviesResponse = _moviesRepository.GetMovies(searchQuery);
            var movies = moviesResponse.Obj;
            var movieTitle = movies.First().Title;
            Assert.IsTrue(movieTitle.ToLower().Contains(searchQuery));
        }


        [TestMethod]
        public void TestMoviesIsSavedOnCache()
        {
            const string searchQuery = "the revenant";
            var moviesResponseFromService = _moviesRepository.GetMovies(searchQuery);

            var isLoadedFromService = !moviesResponseFromService.IsLoadedFromCache;

            var moviesResponseFromCache = _moviesRepository.GetMovies(searchQuery);
            var isLoadedFromCache = moviesResponseFromCache.IsLoadedFromCache;

            Assert.IsTrue(isLoadedFromService);
            Assert.IsTrue(isLoadedFromCache);

        }

    }
}
