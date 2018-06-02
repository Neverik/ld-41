using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anima : MonoBehaviour {

    public State[] states;
    public int current;
    public int prev;

	void Update () {
        if (prev != current)
        {
            Vector3 pos = transform.GetChild(0).position;
            Quaternion rot = transform.GetChild(0).rotation;
            Vector3 scale = transform.GetChild(0).localScale;
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            GameObject go = Instantiate(states[current].meshes[states[current].index], pos, rot, transform);
            go.transform.localScale = scale;
            Change(current);
        }
        prev = current;
	}

    void Change(int cur) {
        if (current != cur) {
            return;
        }
        states[cur].index += 1;
        states[cur].index = Mathf.FloorToInt(Mathf.Repeat(states[cur].index, states[cur].meshes.Length));
        Vector3 pos = transform.GetChild(0).position;
        Quaternion rot = transform.GetChild(0).rotation;
        Vector3 scale = transform.GetChild(0).localScale;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        GameObject go = Instantiate(states[current].meshes[states[current].index], pos, rot, transform);
        go.transform.localScale = scale;
        StartCoroutine("Changer", cur);
    }

    IEnumerator Changer (int cur) {
        yield return new WaitForSeconds(states[current].playBackTime);
        Change(cur);
    }
}

[System.Serializable]
public class State {
    public GameObject[] meshes;
    public string name;
    public float playBackTime;
    public int index;
}
