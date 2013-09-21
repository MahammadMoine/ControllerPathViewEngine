namespace ControllerPathViewEngine
{
    public class ControllerPathSettings
    {
        public string RootNamespace { get; private set; }
        public bool MergeNameIntoNamespace { get; private set; }

        public ControllerPathSettings(string rootNamespace, bool mergeNameIntoNamespace = false)
        {
            RootNamespace = rootNamespace;
            MergeNameIntoNamespace = mergeNameIntoNamespace;
        }
    }
}