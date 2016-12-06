using System.Web.Http;
using Microsoft.Owin;
using Newtonsoft.Json;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pfm.Startup))]
namespace Pfm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }
    }
}
