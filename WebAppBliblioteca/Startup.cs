using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppBliblioteca.Startup))]
namespace WebAppBliblioteca
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
