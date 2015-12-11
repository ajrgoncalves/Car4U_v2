using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(teste_2.Startup))]
namespace teste_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
