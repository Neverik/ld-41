using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition : MonoBehaviour {
    public virtual bool Fulfilled() {
        return false;
    }
}

public enum Mode {
    down,
    normal,
    up
}