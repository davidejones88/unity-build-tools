namespace UnityToolBox.BuildTools
{
    using UnityEngine;

    public partial class BuildToolsEditorWindow
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
            Debug.Log(BuildToolsUtils.LogLabel + "Preparing Addressables");
            UnityEditor.AddressableAssets.Settings.AddressableAssetSettings.BuildPlayerContent();
        }
    }
}
