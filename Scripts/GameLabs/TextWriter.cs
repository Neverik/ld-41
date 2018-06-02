using UnityEngine;
using System.Collections;
using System.Reflection;

public class TextWriter : MonoBehaviour {
    public Component writeTo;
    public string path;
    public string toWrite;
    public float delay;
    public bool finished = false;

    public void Write() {
        StartCoroutine("Wri");
    }

    IEnumerator Wri() {
        FieldInfo info = CopyAction.Unravel(writeTo, path);
        info.SetValue(writeTo, "");
        finished = false;
        foreach (var item in toWrite) {
            info.SetValue(writeTo, (string)info.GetValue(writeTo) + item);
            yield return new WaitForSeconds(delay);
        }
        finished = true;
    }
}
