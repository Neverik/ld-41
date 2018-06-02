using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverCondition : Condition
{

    bool over = false;

    void OnMouseOver()
    {
        over = true;
    }

    void OnMouseExit()
    {
        over = false;
    }

    public override bool Fulfilled()
    {
        return over;
    }
}