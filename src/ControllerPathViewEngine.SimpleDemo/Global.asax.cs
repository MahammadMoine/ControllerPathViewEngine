using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using ControllerPathViewEngine.SimpleDemo.Controllers;

namespace ControllerPathViewEngine.SimpleDemo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            UseCustomViewEngine(ViewEngines.Engines);
        }

        private static void UseCustomViewEngine(ViewEngineCollection viewEngines)
        {
            var settings = new ControllerPathSettings(typeof(HomeController).Namespace, mergeNameIntoNamespace: false);
            var viewEngine = new ControllerPathRazorViewEngine(settings);

            viewEngines.Clear();
            viewEngines.Add(viewEngine);
        }
    }
}