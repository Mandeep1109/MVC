using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcWithEntityF.Startup))]
namespace mvcWithEntityF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
