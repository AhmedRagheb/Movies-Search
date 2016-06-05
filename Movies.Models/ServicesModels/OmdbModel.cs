using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models.ServicesModels
{
    public class OmdbModel
    {
        public string Title { get; set; }

        public string Plot { get; set; }

        public string Released { get; set; }

        public string Poster { get; set; }

        [DisplayName("imdbID")]
        public string Id { get; set; }

        [DisplayName("imdbRating")]
        public double imdbRating { get; set; }

        public int Year { get; set; }
    }
}
