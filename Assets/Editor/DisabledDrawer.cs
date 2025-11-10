using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(DisabledParent), true)]
public class DisabledDrawer : PropertyDrawer
{
    private const string VALUE_PROP_NAME = "_value";

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty valueProp = property.FindPropertyRelative(VALUE_PROP_NAME);

        EditorGUI.BeginDisabledGroup(true);
        EditorGUI.PropertyField(position, valueProp, label, true);
        EditorGUI.EndDisabledGroup();
    }
}
