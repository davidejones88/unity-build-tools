using UnityEditor;
using UnityEngine;

namespace BuildTools
{
    partial class BuildToolsEditorWindow
    {
        private string _buildExtension = "";

        private void ListBuildCommand()
        {
            if (GUILayout.Button("Build"))
            {
                try
                {
                    PreProcessBuild();
                    ExecutePlatformSpecificPreprocess();
                    ExecuteBuild();
                }
                finally 
                {
                    PostProcessBuild();
                    ExecutePlatformSpecificPostProcess();
                }
            }
        }

        private void PreProcessBuild()
        {
            SetScriptingSymbols(_selectedFlags);
        }

        private void ExecuteBuild()
        {
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
            {
                locationPathName = string.Format("{0}/{1}/{2}/{3}{4}", 
                                   BuildToolsUtils.buildPathRoot,
                                   _buildType.ToString(),
                                   _buildTarget.ToString(),
                                   Application.productName,
                                   _buildExtension),
                target = _buildTarget,
                options = _autoRun ? BuildOptions.AutoRunPlayer : BuildOptions.None,
            };

            BuildPipeline.BuildPlayer(buildPlayerOptions);
        }

        private void PostProcessBuild()
        {
            _buildExtension = "";
            SetScriptingSymbols("");
        }

        private void SetScriptingSymbols(string symbols)
        {
            BuildTarget buildTarget = EditorUserBuildSettings.activeBuildTarget;
            BuildTargetGroup buildTargetGroup = BuildPipeline.GetBuildTargetGroup(buildTarget);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, symbols);
        }
    }
}
