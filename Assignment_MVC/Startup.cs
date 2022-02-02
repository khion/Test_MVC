using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment_MVC.Startup))]
namespace Assignment_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
