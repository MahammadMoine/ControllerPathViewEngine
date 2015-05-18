using ControllerPathViewEngine.Tests.TestControllers.Area1.Controllers;
using ControllerPathViewEngine.Tests.TestControllers.Area1.Controllers.AreaLevel1;
using ControllerPathViewEngine.Tests.TestControllers.Area1.Controllers.AreaLevel1.AreaLevel2;
using ControllerPathViewEngine.Tests.TestControllers.Controllers;
using ControllerPathViewEngine.Tests.TestControllers.Controllers.Level1;
using ControllerPathViewEngine.Tests.TestControllers.Controllers.Level1.Level2;
using NUnit.Framework;

namespace ControllerPathViewEngine.Tests
{
    public abstract class shared_context
    {
        protected abstract ControllerPathSettings Settings { get; }

        protected void ExpectPath<T>(string expectedPath)
        {
            var path = GetPath<T>();
            Assert.That(path, Is.EqualTo(expectedPath));
        }

        protected string GetPath<T>()
        {
            var resolver = new ControllerPathResolver(Settings);
            var path = resolver.GetPath(typeof (T));
            return path;
        }
    }

    [TestFixture]
    public class when_resolving_path : shared_context
    {
        protected override ControllerPathSettings Settings
        {
            get
            {
                return new ControllerPathSettings(mergeNameIntoNamespace: false); 
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
        public void paths_at_all_levels_should_start_from_within_controllers_namespace_within_root()
        {
            Assert.That(GetPath<Level1Controller>(), Is.StringStarting("Level1/"));
            Assert.That(GetPath<Level2Controller>(), Is.StringStarting("Level1/"));
        }

        [Test]
        public void paths_at_all_levels_should_start_from_within_controllers_namespace_within_area()
        {
            Assert.That(GetPath<AreaLevel1Controller>(), Is.StringStarting("AreaLevel1/"));
            Assert.That(GetPath<AreaLevel2Controller>(), Is.StringStarting("AreaLevel1/"));
        }

        [Test]
        public void path_for_controller_directly_within_root_controllers_namespace_should_be_based_on_controller_name_only()
        {
            ExpectPath<Level0Controller>("Level0");
        }

        [Test]
        public void path_for_controller_directly_within_area_controllers_namespace_should_be_based_on_controller_name_only()
        {
            ExpectPath<AreaLevel0Controller>("AreaLevel0");
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

    public class when_merging_name_into_namespace: shared_context
    {
        protected override ControllerPathSettings Settings
        {
            get
            {
                return new ControllerPathSettings(mergeNameIntoNamespace: true);
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