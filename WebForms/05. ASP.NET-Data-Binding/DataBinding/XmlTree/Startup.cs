using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XmlTree.Startup))]
namespace XmlTree
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
        }
    }
}
