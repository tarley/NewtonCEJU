using Microsoft.Owin;
using Newton.CJU;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

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