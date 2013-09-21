using System;

namespace ControllerPathViewEngine
{
    public class ControllerPathResolver
    {
        private readonly ControllerPathSettings settings;

        public ControllerPathResolver(ControllerPathSettings settings)
        {
            this.settings = settings;
        }

        public string GetPath(Type controllerType)
        {
            string directoryPath = GetDirectoryPath(controllerType);
            string controllerName = GetControllerName(controllerType);

            bool excludeName = settings.MergeNameIntoNamespace && CanMerge(directoryPath, controllerName);
            
            if (excludeName)
                return directoryPath;
            else if (directoryPath == "")
                return controllerName;
            else
                return string.Format("{0}/{1}", directoryPath, controllerName);
        }

        private static bool CanMerge(string directoryPath, string controllerName)
        {
            return (directoryPath == controllerName || directoryPath.EndsWith(string.Format("/{0}", controllerName)));
        }

        private string GetDirectoryPath(Type controllerType)
        {
            string subPath = controllerType.Namespace ?? "";
            
            if (subPath == settings.RootNamespace)
                return "";

            if (subPath.StartsWith(settings.RootNamespace))
            {
                subPath = subPath.Substring(settings.RootNamespace.Length + 1);
            }
            string directoryPath = subPath.Replace(".", "/");
            return directoryPath;
        }

        private string GetControllerName(Type controllerType)
        {
            string typeName = controllerType.Name;
            if (typeName.EndsWith("Controller", StringComparison.OrdinalIgnoreCase))
            {
                return typeName.Substring(0, typeName.Length - "Controller".Length);
            }
            return typeName;
        }
    }
}