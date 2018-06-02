using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAction : Action
{
    public Rigidbody rb;
    public Vector3 offset;
    public ForceMode mode = ForceMode.Force;
    public bool relative;

    public override void Invoke()
    {
        if (relative)
        {
            rb.AddRelativeForce(offset, mode);
        } else {
            rb.AddForce(offset, mode);
        }
    }
}