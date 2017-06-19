using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoanMVC.Startup))]
namespace LoanMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
