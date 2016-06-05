
namespace Movies.Models.RepositoryModel
{
    public class MovieModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }
        public string ReleaseDate { get; set; }
        public double Vote { get; set; }
        public int ReleaseYear{ get; set; }

        public string EmbededTrailer { get; set; }
    }
}

