using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WAD_Hoang.Startup))]
namespace WAD_Hoang
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
