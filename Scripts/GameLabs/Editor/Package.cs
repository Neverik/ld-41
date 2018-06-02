using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditorInternal;

public class Package : MonoBehaviour {
    public GameObject toLoad;
    public bool loaded = false;
    public void Pack () {
        PrefabUtility.CreatePrefab("Assets/Scripts/" + gameObject.name + ".prefab", gameObject);
    }
    public void Load () {
        foreach (var item in toLoad.GetComponents<MonoBehaviour>()) {
            if (item.GetType() != typeof(Package)) {
                ComponentUtility.CopyComponent(item);
                ComponentUtility.PasteComponentAsNew(gameObject);
            }
        }
        loaded = true;
    }
    void Start() {
        if (!loaded) {
            Load();
        }
    }
}
