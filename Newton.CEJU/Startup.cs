using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Newton.CJU.Startup))]
namespace Newton.CJU
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Configure(app);
        }
    }
}