using Movies.Contracts;
using Movies.Helpers;
using Movies.Services.Omdb;
using Movies.Services.TheMovieDb;
using Movies.Services.YouTube;

namespace Movies.Services.Common
{
    /// <summary>
    /// Factory Class that responsible for Create Movie Service object and Video Service Object
    /// </summary>
    public class ServicesFactory : IServicesFactory
    {
        private readonly IConfigurationsFactory _configurationsFactory;

        public ServicesFactory(IConfigurationsFactory configurationsFactory)
        {
            _configurationsFactory = configurationsFactory;
        }

        /// <summary>
        /// Create Movie Service Object
        /// </summary>
        /// <returns>IMovieService (TheMovieDb,Omdb ...) </returns>
        public IMovieService CreateMovieService()
        {
            switch (ConfigurationHelper.MoviesDbProvider)
            {
                case "TheMovieDb":
                    return new TheMovieDbService(_configurationsFactory);
                case "Omdb":
                    return new OmdbService(_configurationsFactory);

                default:
                    return new TheMovieDbService(_configurationsFactory);
            }
        }

        /// <summary>
        /// Create Video Service Object
        /// </summary>
        /// <returns>IVideoService (YouTube, ...) </returns>
        public IVideoService CreateVideoService()
        {
            return new MyYouTubeService(_configurationsFactory);
        }
    }
}