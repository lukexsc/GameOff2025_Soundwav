using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(InterfaceField), true)]
public class InterfaceFieldDrawer : PropertyDrawer
{
    private const float TEXT_MARGIN = 4f;
    private const int TEXT_SIZE = 9;

    private bool styleCreated;
    private GUIStyle typeStyle;
    private float interfaceWidth;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        var nodeRect = new Rect(position.x, position.y, position.width, position.height);

        // Get Values
        SerializedProperty objProperty = property.FindPropertyRelative("obj");
        InterfaceField fieldObj = property.GetValue<InterfaceField>();

        // Create Type Style
        if (!styleCreated)
        {
            typeStyle = new GUIStyle();
            typeStyle.normal.textColor = new Color(0.7f, 0.7f, 0.7f);
            typeStyle.fontSize = TEXT_SIZE;
            typeStyle.alignment = TextAnchor.MiddleLeft;

            interfaceWidth = typeStyle.CalcSize(new GUIContent(fieldObj.GetInterfaceName())).x + TEXT_MARGIN;
            typeStyle.fixedWidth = interfaceWidth;
            styleCreated = true;
        }

        // Draw fields
        EditorGUI.PrefixLabel(nodeRect, new GUIContent(fieldObj.GetInterfaceName()), typeStyle);

        nodeRect.width -= interfaceWidth;
        nodeRect.x += interfaceWidth;
        EditorGUI.PropertyField(nodeRect, objProperty, GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();

        // Check if it is the Intended Type
        if (objProperty.objectReferenceValue != null && !fieldObj.HasComponentOfType((GameObject)objProperty.objectReferenceValue))
        {
            Debug.LogError(objProperty.objectReferenceValue.name + " does not have any components with the correct interface");
            objProperty.objectReferenceValue = null;
        }
    }
}