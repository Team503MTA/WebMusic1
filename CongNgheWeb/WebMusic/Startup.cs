using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMusic.Startup))]
namespace WebMusic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
