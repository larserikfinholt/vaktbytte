using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vaktbytte.Startup))]
namespace Vaktbytte
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
