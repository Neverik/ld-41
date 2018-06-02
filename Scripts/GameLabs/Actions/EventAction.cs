using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAction : Action
{

    public UnityEngine.Events.UnityEvent action;

    public override void Invoke()
    {
        action.Invoke();
    }

}