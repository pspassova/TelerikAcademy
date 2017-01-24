using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAndHtmlControls.Startup))]
namespace WebAndHtmlControls
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
