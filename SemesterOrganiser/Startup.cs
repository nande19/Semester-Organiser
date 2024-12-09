using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SemesterOrganiser.Startup))]
namespace SemesterOrganiser
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
