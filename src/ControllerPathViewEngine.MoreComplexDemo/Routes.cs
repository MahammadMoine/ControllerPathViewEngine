using System.Web.Routing;
using ControllerPathViewEngine.MoreComplexDemo.Controllers.Catalogue.Categories;
using ControllerPathViewEngine.MoreComplexDemo.Controllers.Catalogue.Products;
using ControllerPathViewEngine.MoreComplexDemo.Controllers.Catalogue.Products.Reviews;
using ControllerPathViewEngine.MoreComplexDemo.Controllers.Home;
using RestfulRouting;
using ControllerPathViewEngine.MoreComplexDemo.Controllers;

[assembly: WebActivator.PreApplicationStartMethod(typeof(ControllerPathViewEngine.MoreComplexDemo.Routes), "Start")]

namespace ControllerPathViewEngine.MoreComplexDemo
{
    public class Routes : RouteSet
    {
        public override void Map(IMapper map)
        {
            map.DebugRoute("routedebug");

            map.Root<HomeController>(x => x.Index());
            
            map.Resources<ProductsController>(products =>
            {
                products.Resources<ReviewsController>();
            });

            map.Resources<CategoriesController>();
        }

        public static void Start()
        {
            var routes = RouteTable.Routes;
            routes.MapRoutes<Routes>();
        }
    }
}