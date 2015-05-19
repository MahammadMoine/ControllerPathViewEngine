# ControllerPathViewEngine

The "flat" view folder structure that you get by default in ASP.Net MVC makes it difficult to structure views in a complex application.

ControllerPathRazorViewEngine is a customised version of the ASP.Net MVC RazorViewEngine that lets you structure your view files in folders that match the namespace hierarchy of your controllers, like this:

<img border="0" height="320" src="https://raw.github.com/danmalcolm/ControllerPathViewEngine/master/src/ControllerPathViewEngine.SimpleDemo/Content/structure.png" width="196" />

## Getting Started

For a component as small as this, there are advantages to simply dropping the code that you need into your project.

1. Add the 3 classes from the [ControllerPathViewEngine](https://github.com/danmalcolm/ControllerPathViewEngine/tree/master/src/ControllerPathViewEngine) class library project to a suitable location in your solution.

2. At startup time within your MVC application (such as within the `Application_Start` method in global.asax), create an instance of `ControllerPathRazorViewEngine` and replace the default ViewEngines in your application:

```C#
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // ... Other startup logic

            var settings = new ControllerPathSettings(mergeNameIntoNamespace: true);
            var viewEngine = new ControllerPathRazorViewEngine(settings);
            viewEngines.Clear();
            viewEngines.Add(viewEngine);
        }
    }

```

## Configuration Options

The following settings can be configured via `ControllerPathSettings`:

<dl>
  <dt>mergeNameIntoNamespace</dt>
  <dd>This controls whether controller type names are merged into the parent namespace.</dd>
</dl>

## Views Folder Structure and Controller Paths


`ControllerPathRazorViewEngine` looks for views using the same locations as the standard ASP.Net MVC `RazorViewEngine`.

Here's a reminder of the standard locations used to find Razor views that include the controller ("{1}" placeholder used for the controller name):

```C#
"~/Areas/{2}/Views/{1}/{0}.cshtml" // AreaViewLocationFormats:
"~/Areas/{2}/Views/{1}/{0}.cshtml" // AreaPartialViewLocationFormats
"~/Views/{1}/{0}.cshtml" // ViewLocationFormats
"~/Views/{1}/{0}.cshtml" // MasterLocationFormats
"~/Views/{1}/{0}.cshtml" // PartialViewLocationFormats

```

Rather than setting the controller path based on the controller name only, `ControllerPathRazorViewEngine` adds additional nested folders based on the namespace of the controller type.

For example, the path to the Index.cshtml view for `ControllerPathViewEngine.SimpleDemo.Controllers.Catalogue.ProductsController` would be: "~/Views/**Catalogue/Products**/Index.cshtml".

The controller path is built up as follows:

* Trim the root namespace (anything up to and including the last "Controllers" element) from the beginning of the controller namespace ("ControllerPathViewEngine.SimpleDemo.Controllers.Catalogue"). This gives us "Catalogue"
* Add an additional folder based on the controller name (without the "Controller" bit at the end).
* This gives us a controller path of "Catalogue/Products". With the action name "Index", this results in a full path of "~/Views/Catalogue/Products/Index.cshtml".

Merging Controller Names with Parent Namespace
----------------------------------------------

Some developers like to locate each controller within its own namespace, as a container for any extra classes that accompany the controller, such as one-off model classes, validators, helpers etc.

The MoreComplexDemo demonstration application demonstrates this structure, for example CategoriesController is located within the namespace ControllerPathViewEngine.MoreComplexDemo.Controllers.Catalogue.Categories.

Using the standard controller path pattern outlined above, we'd end up with an extra level in our view folder hierarchy, like "Catalogue/Categories/Categories/Index.cshtml".

If you would prefer the controller name to be omitted from the controller path if its name matches the parent namespace, then use the mergeNameIntoNamespace setting when initialising the view engine.

## Author

Dan Malcolm - [@lakescoder](http://twitter.com/lakescoder) - http://www.danmalcolm.com

## License

See [UNLICENSE](UNLICENSE.txt)

Please include a reference to this repo if including the source code in your own project, e.g. by including a comment like:

// Adapted from https://github.com/danmalcolm/ControllerPathViewEngine
