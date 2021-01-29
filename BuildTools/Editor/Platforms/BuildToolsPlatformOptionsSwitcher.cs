using UnityEditor;

namespace BuildTools
{
    partial class BuildToolsEditorWindow
    {
        private void LoadTargetSpecificOptions()
        {
            switch (_buildTarget)
            {
                case BuildTarget.Android:
                    LoadAndroidSpecificOptions();
                    break;

                default:
                    break;
            }
        }

        private void ListTargetSpecificUtility()
        {
            switch(_buildTarget)
            {
                case BuildTarget.Android:
                    ListAndroidSpecificOptions();
                    break;

                default:
                    EditorGUILayout.LabelField("No specific Option for this Target");
                    break;
            }
        }

        private void ExecutePlatformSpecificPreprocess()
        {
            switch (_buildTarget)
            {
                case BuildTarget.StandaloneWindows:
                case BuildTarget.StandaloneWindows64:
                    ExecuteWindowsSpecificPreProcess();
                    break;

                case BuildTarget.Android:
                    ExecuteAndroidSpecificPreProcess();
                    break;

                default:
                    break;
            }
        }

        private void ExecutePlatformSpecificPostProcess()
        {
            switch (_buildTarget)
            {
                case BuildTarget.Android:
                    ExecuteAndroidSpecificPostProcess();
                    break;

                default:
                    break;
            }
        }
    }
}
