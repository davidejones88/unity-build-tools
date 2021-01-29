using UnityEditor;
using UnityEngine;

namespace BuildTools
{
    partial class BuildToolsEditorWindow
    {
        enum AndroidExtension
        {
            Apk,
            Aab,
        }

        [SerializeField]
        private AndroidExtension _activeAndroidExtension = AndroidExtension.Aab;

        private string _keyStoreName = "";

        private string _keystorePassword = "";

        private string _keystoreAliasName = "";

        private string _keystoreAliasPassword = "";

        private const string AndroidApkExtension = ".apk";

        private const string AndroidAabExtension = ".aab";

        private void LoadAndroidSpecificOptions()
        {
            _activeAndroidExtension = (AndroidExtension)EditorPrefs.GetInt("_selectedAndroidExtension", (int)_activeAndroidExtension);
        }

        private void ListAndroidSpecificOptions()
        {
            EditorGUI.BeginChangeCheck();

            _activeAndroidExtension = (AndroidExtension)EditorGUILayout.EnumPopup("Extension", _activeAndroidExtension);
            _keyStoreName = EditorGUILayout.TextField("Keystore name", _keyStoreName);
            _keystorePassword = EditorGUILayout.PasswordField("Keystore password", _keystorePassword);
            _keystoreAliasName = EditorGUILayout.TextField("Keystore alias name", _keystoreAliasName);
            _keystoreAliasPassword = EditorGUILayout.PasswordField("Keystore alias password", _keystoreAliasPassword);

            if (EditorGUI.EndChangeCheck())
            {
                EditorPrefs.SetInt("_selectedAndroidExtension", (int)_activeAndroidExtension);
            }
        }

        private void ExecuteAndroidSpecificPreProcess()
        {
            switch(_activeAndroidExtension)
            {
                case AndroidExtension.Apk:
                    _buildExtension = AndroidApkExtension;
                    break;

                case AndroidExtension.Aab:
                    _buildExtension = AndroidAabExtension;
                    break;

                default:
                    _buildExtension = AndroidAabExtension;
                    break;
            }
        }

        private void ExecuteAndroidSpecificPostProcess()
        {
            _keyStoreName = "";
            _keystorePassword = "";
            _keystoreAliasName = "";
            _keystoreAliasPassword = "";
        }
    }
}