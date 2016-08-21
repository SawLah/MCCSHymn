using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApp_MCCSHynm.Startup))]
namespace WebApp_MCCSHynm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
