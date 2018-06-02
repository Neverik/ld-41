using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Motor : MonoBehaviour
{

    public Transform target;
    Transform prevTarget;

    private void Start()
    {
        prevTarget = target;
    }

    void Update()
    {
        if (target != prevTarget)
        {
            GetComponent<NavMeshAgent>().SetDestination(target.position);
            prevTarget = target;
        }
    }
}
