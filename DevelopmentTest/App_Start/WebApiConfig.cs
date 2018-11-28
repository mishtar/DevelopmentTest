using System.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;
using Swashbuckle.Application;

namespace DevelopmentTest
{
    /// <summary>
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            var corsAttributes = new EnableCorsAttribute("*", "*", "GET");
            config.EnableCors(corsAttributes);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "swagger_root",
                "",
                null,
                null,
                new RedirectHandler(message => message.RequestUri.ToString(), "swagger"));

            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            StructuremapWebApi.Start();
        }
    }
}