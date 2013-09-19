using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using ControllerPathViewEngine.WebApp.ViewEngines;

namespace ControllerPathViewEngine.WebApp
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

            UseCustomViewEngine(System.Web.Mvc.ViewEngines.Engines);
        }

        private static void UseCustomViewEngine(ViewEngineCollection viewEngines)
        {
            viewEngines.Clear();
            var settings = new ControllerPathSettings(typeof (MvcApplication).Namespace, mergeNameIntoNamespace: true);
            viewEngines.Add(new ViewEngines.ControllerPathViewEngine(settings));
        }
    }
}