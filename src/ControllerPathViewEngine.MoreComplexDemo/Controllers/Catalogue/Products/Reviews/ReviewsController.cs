using System.Web.Mvc;

namespace ControllerPathViewEngine.MoreComplexDemo.Controllers.Catalogue.Products.Reviews
{
    public class ReviewsController : Controller
    {
        public ActionResult Index(string productId)
        {
            return View();
        }

        public ActionResult Show(string productId, string id)
        {
            return View();
        }
    }
}