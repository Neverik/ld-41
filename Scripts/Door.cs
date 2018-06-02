using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public List<int> keys;
    public Transform newFocus;
    public Transform oldFocus;
    [HideInInspector]
    public bool entered;
}
