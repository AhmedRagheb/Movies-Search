using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Contracts.ServicesContracts
{
    public interface IOmdbServiceConfiguration
    {
        string BaseAddress { get; set; }
    }
}
