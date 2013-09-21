using System.Web.Mvc;

namespace ControllerPathViewEngine.MoreComplexDemo.Controllers.Catalogue.Products
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show(string id)
        {
            return View();
        }

        public ActionResult New()
        {
            return View(); // No view file, for testing exceptions
        }
    }
}