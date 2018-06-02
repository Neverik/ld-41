using UnityEngine;
using System.Collections;

public class RayCondition : Condition {
    public Transform castFrom;

    public override bool Fulfilled () {
        return Physics.Raycast(castFrom.position, castFrom.forward);
    }
}
