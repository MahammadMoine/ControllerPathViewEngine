using ControllerPathViewEngine.WebApp;
using ControllerPathViewEngine.WebApp.Controllers.Level1;
using ControllerPathViewEngine.WebApp.Controllers.Level1.Level2;
using ControllerPathViewEngine.WebApp.ViewEngines;
using NUnit.Framework;

namespace ControllerPathViewEngine.Tests.ViewEngines
{
    public abstract class ResolverSpecification
    {
        protected abstract ControllerPathSettings Settings { get; }

        protected void ExpectPath<T>(string expectedPath)
        {
            var resolver = new ControllerPathResolver(Settings);
            var path = resolver.GetPath(typeof(T));
            Assert.That(path, Is.EqualTo(expectedPath));
        }
    }

    [TestFixture]
    public class ControllerPathResolverSpecs : ResolverSpecification
    {
        protected override ControllerPathSettings Settings
        {
            get
            {
                return new ControllerPathSettings(typeof(MvcApplication).Namespace, mergeNameIntoNamespace: false); 
            }
        }

        [Test]
        public void should_format_path_based_on_namespace_and_controller_name()
        {
            ExpectPath<Level1Controller>("Level1/Level1");
            ExpectPath<AnotherLevel1Controller>("Level1/AnotherLevel1");
            ExpectPath<Level2Controller>("Level1/Level2/Level2");
        }

        [Test]
        public void should_trim_trailing_controller_from_controller_name()
        {
            ExpectPath<Level1Controller>("Level1/Level1");
        }

        [Test]
        public void should_not_trim_trailing_controller_from_controller_with_unconventional_name()
        {
            ExpectPath<Level1ControllerUnconventional>("Level1/Level1ControllerUnconventional");
        }

       
    }

    public class MergingNameIntoNamespaceSpecs: ResolverSpecification
    {
        protected override ControllerPathSettings Settings
        {
            get
            {
                return new ControllerPathSettings(typeof(MvcApplication).Namespace, mergeNameIntoNamespace: true);
            }
        }
            
        [Test]
        public void should_exclude_controller_name_from_path_if_it_matches_containing_namespace()
        {
            ExpectPath<Level1Controller>("Level1");
        }

        [Test]
        public void should_include_controller_name_in_path_if_it_does_not_match_containing_namespace()
        {
            ExpectPath<AnotherLevel1Controller>("Level1/AnotherLevel1");
        }
        
    }
}