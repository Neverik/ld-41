using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditorInternal;
using System.Collections.Generic;

/*
[CustomEditor(typeof(Actor))]
public class ActorEditor : Editor
{
    ReorderableList aList = new ReorderableList(new List<Action>(), typeof(Action));
    ReorderableList bList = new ReorderableList(new List<Condition>(), typeof(Condition));

    void OnEnable()
    {
        aList = new ReorderableList(serializedObject, serializedObject.FindProperty("actions"), true, true, true, true);
        aList.drawElementCallback = (rect, index, isActive, isFocused) => {
            var element = aList.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            //EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, rect.height), element);
        };
        aList.drawHeaderCallback = (rect) => {
            EditorGUI.LabelField(rect, "Actions");
        };
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();
        aList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
        Actor tgt = (Actor)target;
        tgt.any = GUILayout.Toggle(tgt.any, " Any");
        tgt.update = GUILayout.Toggle(tgt.update, " Update");
        tgt.repeat = GUILayout.Toggle(tgt.repeat, " Repeat");
    }
}
*/