using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Serialization;
using System.Linq;

namespace Pfm
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            foreach (var jsonFormatter2 in config.Formatters.OfType<JsonMediaTypeFormatter>())
            {
                jsonFormatter2.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                jsonFormatter2.SerializerSettings.DateFormatString = "yyyy-MM-dd'T'HH:mm:sszz";
            }

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
