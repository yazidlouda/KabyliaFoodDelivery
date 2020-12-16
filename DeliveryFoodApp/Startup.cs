using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeliveryFoodApp.Startup))]
namespace DeliveryFoodApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
