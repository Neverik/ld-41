using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueAction : Action
{
    public Rigidbody rb;
    public Vector3 offset;
    public ForceMode mode = ForceMode.Force;
    public bool relative;

    public override void Invoke()
    {
        if (relative) {
            rb.AddRelativeTorque(offset, mode);
        } else {
            rb.AddTorque(offset, mode);
        }
    }
}