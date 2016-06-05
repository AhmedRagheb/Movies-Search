using System;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.Contracts;
using Movies.Services.TheMovieDb;
using Movies.Services.YouTube;
using RestSharp;

namespace Movies.Tests.Services
{
    [TestClass]
    public class YouTubeSeriveTest
    {
        private IConfigurationsFactory _configurationsFactory;
        private MyYouTubeService _youTubeService;

        [TestInitialize]
        public void Initialize()
        {
            StructureMapConfigureTest.Initialize();
            _configurationsFactory = StructureMapConfigureTest.Container.GetInstance<IConfigurationsFactory>();

            _youTubeService = new MyYouTubeService(_configurationsFactory);
        }


        [TestMethod]
        public void TestYouTubeSearchNotEmpty()
        {
            var embededVideoKey = _youTubeService.Search("Braveheart");
            Assert.IsTrue(!string.IsNullOrEmpty(embededVideoKey));
        }

        [TestMethod]
        public void TestYouTubeSearchIsRelevant()
        {
            var embededVideoKey = _youTubeService.Search("the revenant");
            Assert.AreEqual(embededVideoKey, "LoebZZ8K5N0");
        }

        [TestMethod]
        public void TestYouTubeSearchIsRelevant2()
        {
            var embededVideoKey = _youTubeService.Search("Bridge of Spies");
            Assert.AreEqual(embededVideoKey, "mBBuzHrZBro");
        }
    }
}
