using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Contracts
{
    public interface IYouTubeConfiguration
    {
        string SearchType { get; set; }
        string ApiKey { get; set; }
        int MaxResult { get; set; }
        string SearchPart { get; set; }
    }

}
