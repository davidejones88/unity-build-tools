using UnityEditor;
using UnityEngine;

namespace BuildTools
{
    partial class BuildToolsEditorWindow
    {   
        enum BuildType
        {
            Development,
            Production
        }

        [SerializeField]
        private BuildTarget _buildTarget = BuildTarget.StandaloneWindows;

        [SerializeField]
        private BuildType _buildType = BuildType.Development;

        [SerializeField]
        private string _developmentFlags = "";

        [SerializeField]
        private string _productionFlags = "";

        [SerializeField]
        private bool _autoRun = false;

        private string _selectedFlags = "";

        private void LoadBuildOptions()
        {
            _buildTarget = (BuildTarget)EditorPrefs.GetInt("_buildTarget", (int)_buildTarget);
            _buildType = (BuildType)EditorPrefs.GetInt("_buildType", (int)_buildType);
            _developmentFlags = EditorPrefs.GetString("_developmentFlags", _developmentFlags);
            _productionFlags = EditorPrefs.GetString("_productionFlags", _productionFlags);
            _autoRun = EditorPrefs.GetBool("_autoRun", _autoRun);
        }

        private void ListBuildUtility()
        {
            EditorGUI.BeginChangeCheck();

                _buildTarget = (BuildTarget)EditorGUILayout.EnumPopup("Build Target", _buildTarget);

            if(EditorGUI.EndChangeCheck())
            {
                EditorPrefs.SetInt("_buildTarget", (int)_buildTarget);
                LoadTargetSpecificOptions();
            }

            EditorGUI.BeginChangeCheck();

                _buildType = (BuildType)EditorGUILayout.EnumPopup("Build Type", _buildType);
                if(_buildType == BuildType.Development)
                {
                    _developmentFlags = EditorGUILayout.TextField("Development Flags", _developmentFlags);
                    _selectedFlags = _developmentFlags;
                }
                else 
                {
                    _productionFlags = EditorGUILayout.TextField("Production Flags", _productionFlags);
                    _selectedFlags = _productionFlags;
                }
                _autoRun = EditorGUILayout.Toggle("Auto Run", _autoRun);

            if(EditorGUI.EndChangeCheck())
            {
                EditorPrefs.SetInt("_buildType", (int)_buildType);
                EditorPrefs.SetString("_developmentFlags", _developmentFlags);
                EditorPrefs.SetString("_productionFlags", _productionFlags);
                EditorPrefs.SetBool("_autoRun", _autoRun);
            }
        }
    }
}
