using UnityEngine;

namespace BuildTools
{
    partial class BuildToolsEditorWindow
    {
        static public void ListPrepareUtility()
        {
            if (GUILayout.Button("Prepare Addressables"))
            {
                PrepareAddressables();
            }
        }

        static public void PrepareAddressables()
        {
            Debug.Log(BuildToolsUtils.logLabel + "Preparing Addressables");
            UnityEditor.AddressableAssets.Settings.AddressableAssetSettings.BuildPlayerContent();
        }
    }
}
