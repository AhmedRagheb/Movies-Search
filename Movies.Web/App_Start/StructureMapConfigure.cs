using Movies.Contracts;
using Movies.Contracts.RepositoryContracts;
using Movies.Repository;
using Movies.Services.Common;
using StructureMap;

namespace Movies.Web
{
    /// <summary>
    /// Configure dependency injection Container using Structure Map
    /// </summary>
    public static class StructureMapConfigure
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
