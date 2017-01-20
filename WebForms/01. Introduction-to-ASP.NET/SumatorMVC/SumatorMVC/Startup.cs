using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SumatorMVC.Startup))]
namespace SumatorMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
