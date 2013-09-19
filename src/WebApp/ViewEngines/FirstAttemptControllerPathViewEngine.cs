using System.Web.Mvc;

namespace ControllerPathViewEngine.WebApp.ViewEngines
{
//    public class FirstAttemptControllerPathViewEngine : RazorViewEngine
//    {
//        private const string ControllerPathToken = "[[ControllerPath]]";
//
//        private readonly ControllerPathResolver controllerPathResolver;
//
//        public FirstAttemptControllerPathViewEngine(ControllerPathSettings settings)
//            : this(null, settings)
//        {
//
//        }
//
//        public FirstAttemptControllerPathViewEngine(IViewPageActivator viewPageActivator, ControllerPathSettings settings)
//            : base(viewPageActivator)
//        {
//            controllerPathResolver = new ControllerPathResolver(settings);
//
//            AreaViewLocationFormats = new[]
//                {
//                    "~/Areas/{2}/Views/[[ControllerPath]]/{0}.cshtml",
//                    "~/Areas/{2}/Views/[[ControllerPath]]/{0}.vbhtml",
//                    "~/Areas/{2}/Views/Shared/{0}.cshtml",
//                    "~/Areas/{2}/Views/Shared/{0}.vbhtml"
//                };
//            AreaMasterLocationFormats = new[]
//                {
//                    "~/Areas/{2}/Views/[[ControllerPath]]/{0}.cshtml",
//                    "~/Areas/{2}/Views/[[ControllerPath]]/{0}.vbhtml",
//                    "~/Areas/{2}/Views/Shared/{0}.cshtml",
//                    "~/Areas/{2}/Views/Shared/{0}.vbhtml"
//                };
//            AreaPartialViewLocationFormats = new[]
//                {
//                    "~/Areas/{2}/Views/[[ControllerPath]]/{0}.cshtml",
//                    "~/Areas/{2}/Views/[[ControllerPath]]/{0}.vbhtml",
//                    "~/Areas/{2}/Views/Shared/{0}.cshtml",
//                    "~/Areas/{2}/Views/Shared/{0}.vbhtml"
//                };
//
//            ViewLocationFormats = new[]
//                {
//                    "~/Views/[[ControllerPath]]/{0}.cshtml",
//                    "~/Views/[[ControllerPath]]/{0}.vbhtml",
//                    "~/Views/Shared/{0}.cshtml",
//                    "~/Views/Shared/{0}.vbhtml"
//                };
//            MasterLocationFormats = new[]
//                {
//                    "~/Views/[[ControllerPath]]/{0}.cshtml",
//                    "~/Views/[[ControllerPath]]/{0}.vbhtml",
//                    "~/Views/Shared/{0}.cshtml",
//                    "~/Views/Shared/{0}.vbhtml"
//                };
//            PartialViewLocationFormats = new[]
//                {
//                    "~/Views/[[ControllerPath]]/{0}.cshtml",
//                    "~/Views/[[ControllerPath]]/{0}.vbhtml",
//                    "~/Views/Shared/{0}.cshtml",
//                    "~/Views/Shared/{0}.vbhtml"
//                };
//
//            FileExtensions = new[]
//                {
//                    "cshtml",
//                    "vbhtml",
//                };
//        }
//
//        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
//        {
//            string fullPartialPath = IncludeControllerPath(controllerContext, partialPath);
//            return base.CreatePartialView(controllerContext, fullPartialPath);
//        }
//
//        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
//        {
//            string fullViewPath = IncludeControllerPath(controllerContext, viewPath);
//            string fullMasterPath = IncludeControllerPath(controllerContext, masterPath);
//            return base.CreateView(controllerContext, fullViewPath, fullMasterPath);
//        }
//
//        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
//        {
//            string fullVirtualPath = IncludeControllerPath(controllerContext, virtualPath);
//            return base.FileExists(controllerContext, fullVirtualPath);
//        }
//
//        private string IncludeControllerPath(ControllerContext controllerContext, string viewPath)
//        {
//            var controllerType = controllerContext.Controller.GetType();
//            string controllerPath = controllerPathResolver.GetPath(controllerType);
//            return viewPath.Replace(ControllerPathToken, controllerPath);
//        }
//    }
}