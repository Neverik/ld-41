using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAction : Action {
    public float a;
    public float b;
    public float c;
    public string op;

    public override void Invoke()
    {
        switch (op)
        {
            case "plus":
                c = a + b;
                break;
            case "minus":
                c = a - b;
                break;
            case "times":
                c = a * b;
                break;
            case "div":
                c = a / b;
                break;
        }
    }
}
