using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cheques.Startup))]
namespace Cheques
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
