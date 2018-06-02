using UnityEngine;
using System.Collections;

public class RayAction : Action {
    public Transform castFrom;
    public RaycastHit hit;

    public override void Invoke () {
        Physics.Raycast(castFrom.position, castFrom.forward, out hit);
    }
}
