using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LifecycleEvents.Startup))]
namespace LifecycleEvents
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
