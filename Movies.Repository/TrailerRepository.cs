using Movies.Contracts;
using Movies.Contracts.RepositoryContracts;
using Movies.Services.Common;

namespace Movies.Repository
{
    public class TrailerRepository : ITrailerRepository
    {
        private readonly IVideoService _videoService;
        /// <summary>
        /// Constractor, Init the videos service object
        /// </summary>
        /// <param name="servicesFactory">Current Selected Service (YouTube, ... )</param>
        public TrailerRepository(IServicesFactory servicesFactory)
        {
            _videoService = servicesFactory.CreateVideoService();
        }

        /// <summary>
        /// Get Video Trailer
        /// </summary>
        /// <param name="movieName"> Movie Name</param>
        /// <returns>Embeded Video Key</returns>
        public string GetTrailer(string movieName)
        {
            var embeddedKey = _videoService.Search(movieName);
            return embeddedKey;
        }
    }
}
