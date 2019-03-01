using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DMUViews.Startup))]
namespace DMUViews
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
