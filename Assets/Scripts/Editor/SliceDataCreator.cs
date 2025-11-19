#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public static class SliceDataCreator
{
    [MenuItem("Tools/Wheel/Create SliceData Batch", false, 1)]
    public static void CreateSliceDataBatch()
    {
        string path = EditorUtility.OpenFolderPanel("Select Folder for SliceData", "Assets", "");
        if (string.IsNullOrEmpty(path)) return;

        path = FileUtil.GetProjectRelativePath(path);

        for (int i = 1; i <= 8; i++)
        {
            string assetPath = $"{path}/slice_reward_{i}.asset";
            var data = ScriptableObject.CreateInstance<SliceData>();

            data._id = $"reward_{i}";
            data._sliceType = SliceType.Reward;
            data._baseAmount = i * 10;

            AssetDatabase.CreateAsset(data, assetPath);
        }

        // Bomb
        var bomb = ScriptableObject.CreateInstance<SliceData>();
        bomb._id = "bomb";
        bomb._sliceType = SliceType.Bomb;
        bomb._baseAmount = 0;
        AssetDatabase.CreateAsset(bomb, $"{path}/slice_bomb.asset");

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("SliceData Batch Created!");
    }
}
#endif