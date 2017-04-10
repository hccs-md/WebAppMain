using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppMain.Startup))]
namespace WebAppMain
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
