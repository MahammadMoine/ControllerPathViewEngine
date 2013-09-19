using System.Web.Mvc;

namespace ControllerPathViewEngine.WebApp.Controllers.Level1.Level2
{
    public class Level2Controller : Controller
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