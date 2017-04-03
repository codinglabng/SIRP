using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PRIS.Startup))]
namespace PRIS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
