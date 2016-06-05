using System;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.Contracts;
using Movies.Repository;

namespace Movies.Tests.Repositories
{
    [TestClass]
    public class TrailerRepoTest
    {
        private IServicesFactory _servicesFactory;
        private TrailerRepository _trailerRepository;

        [TestInitialize]
        public void Initialize()
        {
            StructureMapConfigureTest.Initialize();
            _servicesFactory = StructureMapConfigureTest.Container.GetInstance<IServicesFactory>();
           
            _trailerRepository = new TrailerRepository(_servicesFactory);
        }


        [TestMethod]
        public void TestTrailerRepoIsReturnRelevantData()
        {
            var embededVideoKey = _trailerRepository.GetTrailer("the revenant");
            Assert.AreEqual(embededVideoKey, "LoebZZ8K5N0");
        }

        [TestMethod]
        public void TestTrailerRepoIsReturnRelevantData2()
        {
            var embededVideoKey = _trailerRepository.GetTrailer("Bridge of Spies");
            Assert.AreEqual(embededVideoKey, "mBBuzHrZBro");
        }
    }
}
