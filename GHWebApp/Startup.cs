using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GHWebApp.Startup))]
namespace GHWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
