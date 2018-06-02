using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force2DAction : Action {

    public Rigidbody2D rb;
    public Vector2 force;
    public bool isRelative;
    public ForceMode2D mode;

    public override void Invoke() {
        if (isRelative) {
            rb.AddRelativeForce(force, mode);
        } else {
            rb.AddRelativeForce(force, mode);
        }
    }
}
