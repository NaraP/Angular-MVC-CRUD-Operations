using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngularCRUDMVCApplication.Startup))]
namespace AngularCRUDMVCApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
