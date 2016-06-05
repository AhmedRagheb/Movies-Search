using System.Collections.Generic;
using System.ComponentModel;

namespace Movies.Models.ServicesModels
{
    public class TheMoviesDbSearchResultsModel
    {
        public int page { get; set; }
        public List<TheMoviesDbSearchModel> results { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
    }

    public class TheMoviesDbSearchModel
    {
        public string poster_path { get; set; }
        public string overview { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }
        public string release_date { get; set; }
    }
}

