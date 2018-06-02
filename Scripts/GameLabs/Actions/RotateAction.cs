using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAction : Action
{
    public Transform toMove;
    public Vector3 offset;
    public float offsetX = 0;
    public float offsetY = 0;
    public float offsetZ = 0;
    public Space space;

    public override void Invoke() {
        toMove.Rotate(offset, space);
        toMove.Rotate(new Vector3(offsetX, offsetY, offsetZ), space);
    }
}