using System.Web.Mvc;

namespace ControllerPathViewEngine.SimpleDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        } 

    }
}