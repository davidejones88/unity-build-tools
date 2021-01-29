using UnityEditor;
using UnityEngine;

namespace BuildTools
{
    partial class BuildToolsEditorWindow : EditorWindow
    {
        [MenuItem("BuildTools/Open BuildTools")]
        static private void OpenBuildTools()
        {
            GetWindow(typeof(BuildToolsEditorWindow), false, "BuildTools", true);
        }

        private void OnEnable()
        {
            LoadBuildOptions();
            LoadTargetSpecificOptions();
        }

        private void OnGUI()
        {
            EditorGUILayout.Space(10);

            EditorGUILayout.LabelField("Clean Utility", EditorStyles.boldLabel);
            ListCleanUtility();
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            EditorGUILayout.LabelField("Prepare Utility", EditorStyles.boldLabel);
            ListPrepareUtility();
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            EditorGUILayout.LabelField("Shared Build Options", EditorStyles.boldLabel);
            ListBuildUtility();
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            EditorGUILayout.LabelField("Target Specific Build Options", EditorStyles.boldLabel);
            ListTargetSpecificUtility();
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            ListBuildCommand();
            EditorGUILayout.Space(10);

            EditorGUILayout.LabelField("BuildTools 1.0.0", EditorStyles.centeredGreyMiniLabel);
        }
    }
}
