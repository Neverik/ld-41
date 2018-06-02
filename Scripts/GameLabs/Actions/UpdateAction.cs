using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAction : Action {
    public IOHelper toUpdate;
    public override void Invoke()
    {
        toUpdate.UpdateStats();
    }
}
