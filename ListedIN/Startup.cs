using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ListedIN.Startup))]
namespace ListedIN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
