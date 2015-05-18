namespace ControllerPathViewEngine
{
    public class ControllerPathSettings
    {
        public bool MergeNameIntoNamespace { get; private set; }

        public ControllerPathSettings(bool mergeNameIntoNamespace = false)
        {
            MergeNameIntoNamespace = mergeNameIntoNamespace;
        }
    }
}