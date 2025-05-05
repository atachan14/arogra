using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(OptionalFloat))]
public class OptionalFloatDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // labelの描画（左側のフィールド名）
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // useとvalueを横に分割
        float toggleWidth = 20f;
        float padding = 5f;
        Rect toggleRect = new Rect(position.x, position.y, toggleWidth, position.height);
        Rect floatRect = new Rect(position.x + toggleWidth + padding, position.y, position.width - toggleWidth - padding, position.height);

        // 実際のプロパティ
        SerializedProperty useProp = property.FindPropertyRelative("use");
        SerializedProperty valueProp = property.FindPropertyRelative("value");

        useProp.boolValue = EditorGUI.Toggle(toggleRect, useProp.boolValue);
        EditorGUI.PropertyField(floatRect, valueProp, GUIContent.none);
    }
}


