using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCondition : Condition
{
    bool col = false;
    public bool tagged;
    public string searchForTag;

    void OnCollisionEnter(Collision collision)
    {
        if (tagged)
        {
            if (collision.collider.tag == searchForTag)
            {
                col = true;
                return;
            }
        }
        col = true;
            
    }

    void OnCollisionExit(Collision collision)
    {
        if (tagged)
        {
            if (collision.collider.tag == searchForTag)
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