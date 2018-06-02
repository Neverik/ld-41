using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCondition : Condition
{
    bool col = false;
    public bool tagged;
    public string searchForTag;

    void OnTriggerEnter(Collider collide)
    {
        if (tagged)
        {
            if (collide.tag == searchForTag)
            {
                col = true;
                return;
            }
        }
        col = true;
    }

    void OnTriggerExit(Collider collide)
    {
        if (tagged)
        {
            if (collide.tag == searchForTag)
            {
                col = false;
                return;
            }
        }
        col = false;
    }

    public override bool Fulfilled()
    {
        return col;
    }
}
