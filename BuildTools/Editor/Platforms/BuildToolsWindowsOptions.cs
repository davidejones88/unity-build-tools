namespace BuildTools
{
    partial class BuildToolsEditorWindow
    {
        private const string WindowsExtension = ".exe";

        private void ExecuteWindowsSpecificPreProcess()
        {
            _buildExtension = WindowsExtension;
        }
    }
}
