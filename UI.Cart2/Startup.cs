using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UI.Cart2.Startup))]
namespace UI.Cart2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
