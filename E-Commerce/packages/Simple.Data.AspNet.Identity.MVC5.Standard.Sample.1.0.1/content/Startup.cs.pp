using Microsoft.Owin;
using $rootnamespace$;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace $rootnamespace$
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
