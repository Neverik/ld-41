using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCondition : Condition
{

    public float minDistance;
    public Transform to;

    public override bool Fulfilled()
    {
        return Vector3.Distance(transform.position, to.position) < minDistance;
    }

}