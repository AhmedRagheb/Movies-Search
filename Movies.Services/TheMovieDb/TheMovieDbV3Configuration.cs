
using Movies.Contracts;

namespace Movies.Services.TheMovieDb
{
   
    public class TheMovieDbV3Configuration : ITheMovieDbConfiguration
    {
        private static string _baseAddress = "http://api.themoviedb.org/3/";
        public string BaseAddress
        {
            get { return _baseAddress; }
            set { _baseAddress = value; }
        }

        private static string _apiKey = "{your key}";
        public string ApiKey
        {
            get { return _apiKey; }
            set { _apiKey = value; }
        }

    }
}
