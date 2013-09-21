using System.Web.Mvc;

namespace ControllerPathViewEngine.SimpleDemo.Controllers.Catalogue
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MissingView()
        {
            return View();
        }
    }
}