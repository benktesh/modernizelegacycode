using System.Web.Routing;
using System.Web.Http;

namespace ModernizeLegacyCode
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
