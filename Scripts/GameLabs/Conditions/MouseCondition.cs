using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCondition : Condition
{

    public int mouseButton;
    public Mode mode;

    public override bool Fulfilled()
    {
        switch (mode)
        {
            case Mode.down:
                if (Input.GetMouseButtonDown(mouseButton))
                {
                    return true;
                }
                break;
            case Mode.normal:
                if (Input.GetMouseButton(mouseButton))
                {
                    return true;
                }
                break;
            case Mode.up:
                if (Input.GetMouseButtonUp(mouseButton))
                {
                    return true;
                }
                break;
        }
        return false;
    }
}