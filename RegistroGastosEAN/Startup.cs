using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegistroGastosEAN.Startup))]
namespace RegistroGastosEAN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
