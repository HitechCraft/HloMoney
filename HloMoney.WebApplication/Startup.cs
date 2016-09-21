using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HloMoney.WebApplication.Startup))]
namespace HloMoney.WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
