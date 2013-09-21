using System.Web.Mvc;

namespace ControllerPathViewEngine.MoreComplexDemo.Controllers.Catalogue.Categories
{
    public class CategoriesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show(string id)
        {
            return View();
        }

    }
}