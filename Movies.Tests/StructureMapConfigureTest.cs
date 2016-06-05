using Movies.Contracts;
using Movies.Contracts.RepositoryContracts;
using Movies.Repository;
using Movies.Services.Common;
using StructureMap;

namespace Movies.Tests
{
    /// <summary>
    /// Configure dependency injection Container using Structure Map
    /// </summary>
    public static class StructureMapConfigureTest
    {
        public static IContainer Container;

        public static IContainer Initialize()
        {
            Container = new Container(_ =>
            {
                _.For<IConfigurationsFactory>().Use<ConfigurationsFactory>().Singleton();
                _.For<IServicesFactory>().Use<ServicesFactory>().Singleton();
                _.For<IMoviesRepository>().Use<MoviesRepository>();
                _.For<ITrailerRepository>().Use<TrailerRepository>();
            });


            return Container;
        }
    }
}
