

using Movies.Contracts.ServicesContracts;

namespace Movies.Services.Omdb
{
    public class OmdbServiceConfiguration : IOmdbServiceConfiguration
    {
        private static string _baseAddress = "http://www.omdbapi.com/";
        public string BaseAddress
        {
            get { return _baseAddress; }
            set { _baseAddress = value; }
        }

    }
}
