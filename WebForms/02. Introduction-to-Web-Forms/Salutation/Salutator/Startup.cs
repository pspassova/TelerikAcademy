using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Salutator.Startup))]
namespace Salutator
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
