ControllerPathViewEngine
========================

Introduction
------------

The "flat" view folder structure that you get by default in ASP.Net MVC makes it difficult to structure views in a complex application.

ControllerPathRazorViewEngine is a customised version of the ASP.Net MVC RazorViewEngine that lets you structure your view files in folders that match the namespace hierarchy of your controllers, like this:

<img border="0" height="320" src="https://raw.github.com/danmalcolm/ControllerPathViewEngine/master/src/ControllerPathViewEngine.SimpleDemo/Content/structure.png" width="196" />

A couple of online demos and link to introductory blog post coming soon.

Getting Started
---------------

For a component as small as this, there are advantages to simply dropping the code that you need into your project - and that's how this works. 

1. Add the 3 classes from the [ControllerPathViewEngine] [1] class library project to a suitable location in your solution.

2. At startup time within your MVC application, create an instance of ControllerPathRazorViewEngine and use it to replace the default ViewEngines - see global.asax in one of the demo projects.


Configuration Options
---------------------

Note that you need to provide an instance of ControllerPathSettings to the ControllerPathRazorViewEngine constructor. This settings class has 2 options:

<dl>
  <dt>rootNamespace</dt>
  <dd>This is the parent controller namespace and controls where your views folder hierarchy "starts"</dd>
  <dt>mergeNameIntoNamespace</dt>
  <dd>This controls whether controller type names are merged into the parent namespace.</dd>
</dl>

Views Folder Structure and Controller Paths
-------------------------------------------

ControllerPathRazorViewEngine looks for views in a folder that is based on the namespace of the controller rendering the view.

Pattern: Views/{controller path}/{view name}.{view file extension}
Example: Views/Catalogue/Products/Index.cshtml

The "controller path" part is based on a combination of the controller namespace and controller name.

Let's use ProductsController in namespace ControllerPathViewEngine.SimpleDemo.Controllers.Catalogue as an example and assume that we've used "ControllerPathViewEngine.SimpleDemo.Controllers" as our rootNamespace setting when initialising the view engine.

The controller path would be generated as follows:

* Trim the root namespace ("ControllerPathViewEngine.SimpleDemo.Controllers") from the beginning of the controller namespace ("ControllerPathViewEngine.SimpleDemo.Controllers.Catalogue"). This gives us "Catalogue"
* Add an additional folder based on the controller name (without the "Controller" bit at the end). This gives us: "Catalogue/Products"

In our example, the controller path would be "Catalogue/Products" and the full path to the "Index" razor view would be "Views/Catalogue/Products/Index.cshtml"


Merging Controller Names with Parent Namespace
----------------------------------------------

Some developers like to locate each controller within its own namespace. If you're a good follower of the Single Responsibility Principle, you might have a few extra classes that help the controller do its work, things like one-off model classes, validators etc.

The MoreComplexDemo demonstration application demonstrates this structure, for example CategoriesController is located within the namespace ControllerPathViewEngine.MoreComplexDemo.Controllers.Catalogue.Categories.

Using the standard controller path pattern outlined above, we'd end up with an extra level in our view folder hierarchy, like "Catalogue/Categories/Categories/Index.cshtml".

If you would prefer the controller name to be omitted from the controller path if its name matches the parent namespace, then use the mergeNameIntoNamespace setting when initialising the view engine.

[1]: https://github.com/danmalcolm/ControllerPathViewEngine/tree/master/src/ControllerPathViewEngine "ControllerPathViewEngine"