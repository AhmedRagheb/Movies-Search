
using Movies.Contracts;
using Movies.Contracts.ServicesContracts;
using Movies.Services.Omdb;
using Movies.Services.TheMovieDb;
using Movies.Services.YouTube;
using StructureMap;

namespace Movies.Services.Common
{
    /// <summary>
    /// Create Movie DB Configuration object, This give flexability to support 
    /// multiple Configurations V4, V5 .. and single point to change 
    /// </summary>
    /// <returns></returns>
 
    public class ConfigurationsFactory : IConfigurationsFactory
    {
        /// <summary>
        /// Configurations for TheMovieDb Service
        /// </summary>
        /// <returns></returns>
        public ITheMovieDbConfiguration CreateMovieDbConfiguration()
        {
            return new TheMovieDbV3Configuration();
        }

        /// <summary>
        /// Configurations for Omdb Service
        /// </summary>
        /// <returns></returns>
        public IOmdbServiceConfiguration CreateOmdbServiceConfiguration()
        {
            return new OmdbServiceConfiguration();
        }

        /// <summary>
        /// Configurations for YouTube
        /// </summary>
        /// <returns></returns>
        public IYouTubeConfiguration CreateYouTubeConfiguration()
        {
            return new YouTubeConfiguration();
        }
    }
}
