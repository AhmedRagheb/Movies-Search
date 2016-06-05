
using Movies.Contracts;

namespace Movies.Services.YouTube
{
   

    public class YouTubeConfiguration : IYouTubeConfiguration
    {
        private static string _searchType = "video";
        public string SearchType
        {
            get { return _searchType; }
            set { _searchType = value; }
        }

        private static int _maxResult = 1;
        public int MaxResult
        {
            get { return _maxResult; }
            set { _maxResult = value; }
        }

        private static string _searchPart = "snippet";
        public string SearchPart
        {
            get { return _searchPart; }
            set { _searchPart = value; }
        }

        private static string _apiKey = "{your key}";
        public string ApiKey
        {
            get { return _apiKey; }
            set { _apiKey = value; }
        }


    }
}
