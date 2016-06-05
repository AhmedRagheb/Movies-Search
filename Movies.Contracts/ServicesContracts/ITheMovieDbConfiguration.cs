using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Contracts
{
    public interface ITheMovieDbConfiguration
    {
        string BaseAddress { get; set; }
        string ApiKey { get; set; }
    }

}
