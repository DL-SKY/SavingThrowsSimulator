using Modules.Windows.Components;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

[CustomEditor(typeof(NewButton), true)]
[CanEditMultipleObjects]
public class NewButtonEditor : ButtonEditor
{
    private SerializedProperty _onDisableClickProperty;    
    private SerializedProperty _tag;

    protected override void OnEnable()
    {
        base.OnEnable();

        _onDisableClickProperty = serializedObject.FindProperty("_onDisableClick");
        _tag = serializedObject.FindProperty("_tag");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(_tag);
        serializedObject.ApplyModifiedProperties();

        if (NewButton.AvailableTags.Count > 0)
            GUILayout.Label($"Available Tags:\n    {string.Join(",\n    ", NewButton.AvailableTags)}");
        else
            GUILayout.Label($"Available Tags: {{NA}}");

        EditorGUILayout.Space();

        base.OnInspectorGUI();

        EditorGUILayout.Space();

        serializedObject.Update();
        EditorGUILayout.PropertyField(_onDisableClickProperty);
        serializedObject.ApplyModifiedProperties();
    }
}
