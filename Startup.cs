using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Scott_MIS4200_1045.Startup))]
namespace Scott_MIS4200_1045
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
