using System.Web;
using System.Web.Http;

namespace OneMoreThing.ApiExample
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}