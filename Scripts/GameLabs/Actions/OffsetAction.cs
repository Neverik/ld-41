using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetAction : Action
{
    public Transform toMove;
    public Vector3 offset;
    public Space space;

    public override void Invoke()
    {
        toMove.Translate(offset, space);
    }
}