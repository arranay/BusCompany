using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusCompany.Startup))]
namespace BusCompany
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
