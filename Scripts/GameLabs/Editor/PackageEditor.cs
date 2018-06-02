using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Package))]
class PackageEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if (GUILayout.Button("Pack components")) {
            ((Package)target).Pack();
        }
        if (GUILayout.Button("Load component")) {
            ((Package)target).Load();
        }
    }
}
