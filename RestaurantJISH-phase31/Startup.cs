using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestaurantJISH_phase31.Startup))]
namespace RestaurantJISH_phase31
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
