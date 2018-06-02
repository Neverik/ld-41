using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysCondition : Condition {

    public override bool Fulfilled() {
        return true;
    }
}
