using UnityEngine;
using UnityEditor;
using System;

public class CreateAssetFromScript : Editor
{
    [MenuItem("Assets/Create/ThisScriptebleObject", false,1)]
    public static void CreateManager()
    {
        ScriptableObject asset = ScriptableObject.CreateInstance(Selection.activeObject.name);
        AssetDatabase.CreateAsset(asset, AssetDatabase.GetAssetPath(Selection.activeObject).Replace(".cs", ".asset"));
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}