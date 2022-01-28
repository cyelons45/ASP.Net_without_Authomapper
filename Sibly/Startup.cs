using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sibly.Startup))]
namespace Sibly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
