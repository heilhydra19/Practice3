using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Practice3.Startup))]
namespace Practice3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
