
namespace Movies.Contracts
{
    /// <summary>
    /// Public Factory Interface for all Movies and Trailers Services 
    /// </summary>
    public interface IServicesFactory
    {
        IMovieService CreateMovieService();

        IVideoService CreateVideoService();
    }
}