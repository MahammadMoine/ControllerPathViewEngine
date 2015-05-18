using System;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace ControllerPathViewEngine
{
    public class ControllerPathResolver
    {
        private readonly ConcurrentDictionary<Type,string> paths = new ConcurrentDictionary<Type, string>(); 
        private readonly ControllerPathSettings settings;

        public ControllerPathResolver(ControllerPathSettings settings)
        {
            this.settings = settings;
        }

        public string GetPath(Type controllerType)
        {
            return paths.GetOrAdd(controllerType, GetControllerPath);
        }

        private string GetControllerPath(Type controllerType)
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
            // Whether in default Controllers folder or an area, the controller path
            // will be based on namespace elements within the parent "Controllers"
            // namespace element

            string subNamespace = controllerType.Namespace ?? "";
            const string parentNamespacePart = "Controllers";
            int index = subNamespace.LastIndexOf(parentNamespacePart, StringComparison.OrdinalIgnoreCase);
            if (index != -1)
            {
                subNamespace = subNamespace.Substring(index + parentNamespacePart.Length)
                    .TrimStart('.');
            }
            
            string directoryPath = subNamespace.Replace(".", "/");
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