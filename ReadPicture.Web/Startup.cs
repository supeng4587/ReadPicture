using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReadPicture.Web.Startup))]
namespace ReadPicture.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
