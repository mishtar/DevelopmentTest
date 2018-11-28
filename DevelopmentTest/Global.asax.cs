using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using DevelopmentTest.Model.Automapper;

namespace DevelopmentTest
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        /// </summary>
        protected void Application_Start()
        {
            AutoMapperConfiguration.Configure();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}