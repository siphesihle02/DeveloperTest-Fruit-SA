using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeveloperTest_Fruit_SA.Startup))]
namespace DeveloperTest_Fruit_SA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
