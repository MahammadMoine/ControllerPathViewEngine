using System.Web.Mvc;

namespace ControllerPathViewEngine.WebApp.Controllers.Level1
{
    public class AnotherLevel1Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        } 

        public ActionResult Missing()
        {
            return View();
        }
    }
}