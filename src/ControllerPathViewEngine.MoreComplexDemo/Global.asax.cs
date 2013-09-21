using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControllerPathViewEngine.MoreComplexDemo
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

        private void UseCustomViewEngine(ViewEngineCollection viewEngines)
        {
            string rootControllerNamespace = typeof(MvcApplication).Namespace + ".Controllers";
            var settings = new ControllerPathSettings(rootControllerNamespace, mergeNameIntoNamespace: true);
            var viewEngine = new ControllerPathRazorViewEngine(settings);

            viewEngines.Clear();
            viewEngines.Add(viewEngine);
        }
    }
}