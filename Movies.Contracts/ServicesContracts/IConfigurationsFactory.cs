using Movies.Contracts.ServicesContracts;

namespace Movies.Contracts
{
    public interface IConfigurationsFactory
    {
        ITheMovieDbConfiguration CreateMovieDbConfiguration();

        IOmdbServiceConfiguration CreateOmdbServiceConfiguration();

        IYouTubeConfiguration CreateYouTubeConfiguration();
    }
}
