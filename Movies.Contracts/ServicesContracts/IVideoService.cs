

namespace Movies.Contracts
{
    /// <summary>
    /// Public Interface any video service should implement
    /// </summary>
    public interface IVideoService
    {
        string Search(string movieName);
    }
}
