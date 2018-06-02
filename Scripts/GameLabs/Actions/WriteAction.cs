using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteAction : Action {

    [TextArea]
    public string toWrite;
    public float disappearance;

    public override void Invoke () {
        Manager.instance.txt.text = toWrite;
        Controller.DeleteText(disappearance);
    }
}
