using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(OptionalParent), true)]
public class OptionalDrawer : PropertyDrawer
{
    private const string ENABLED_PROP_NAME = "enabled";
    private const string VALUE_PROP_NAME = "_value";
    private const float CHECK_WIDTH = 24f;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty enabledProp = property.FindPropertyRelative(ENABLED_PROP_NAME);
        SerializedProperty valueProp = property.FindPropertyRelative(VALUE_PROP_NAME);

        position.width -= CHECK_WIDTH;
        EditorGUI.BeginDisabledGroup(!enabledProp.boolValue);
        EditorGUI.PropertyField(position, valueProp, label, true);
        EditorGUI.EndDisabledGroup();

        position.x += position.width + CHECK_WIDTH;
        position.width = position.height = EditorGUI.GetPropertyHeight(enabledProp);
        position.x -= position.width;

        EditorGUI.PropertyField(position, enabledProp, GUIContent.none);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var valueProp = property.FindPropertyRelative(VALUE_PROP_NAME);
        return EditorGUI.GetPropertyHeight(valueProp);
    }
}
