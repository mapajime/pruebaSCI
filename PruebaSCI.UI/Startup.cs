using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PruebaSCI.UI.Startup))]
namespace PruebaSCI.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
