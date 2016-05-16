using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(TerrainMesh))]
public class TerrainMeshEditorHelper : Editor
{
    private SerializedProperty heightMap;

    void OnEnable()
    {
        heightMap = serializedObject.FindProperty("HeightMap");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(heightMap);
        serializedObject.ApplyModifiedProperties();

        if (GUILayout.Button("Regenerate"))
        {
            ((TerrainMesh)target).GenerateMesh();
        }
    }
}
