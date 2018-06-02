using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAction : Action {
    public GameObject toBuild;
    public Transform whereTo;

    public override void Invoke()
    {
        GameObject.Instantiate(toBuild, whereTo.position, whereTo.rotation, whereTo);
    }
}