using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BudgetWeb.Startup))]
namespace BudgetWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
