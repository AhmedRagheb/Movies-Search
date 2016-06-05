using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Movies.Web.Startup))]
namespace Movies.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
