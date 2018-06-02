using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCondition : Condition
{

    public KeyCode key;
    public Mode mode;

    public override bool Fulfilled()
    {
        switch (mode)
        {
            case Mode.down:
                if (Input.GetKeyDown(key))
                {
                    return true;
                }
                break;
            case Mode.normal:
                if (Input.GetKey(key))
                {
                    return true;
                }
                break;
            case Mode.up:
                if (Input.GetKeyUp(key))
                {
                    return true;
                }
                break;
        }
        return false;
    }
}