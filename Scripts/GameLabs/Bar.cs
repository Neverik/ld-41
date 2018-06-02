using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bar {
    public string key;
    public float value;
    public float defaultValue;
}

[System.Serializable]
public class Bars {
    public Bar[] bars;
}