using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolAction : Action {

    public bool a;
    public bool b;
    public bool c;
    public string op;

    public override void Invoke() {
        switch (op) {
            case "not":
                c = !a;
                break;
            case "or":
                c = a || b;
                break;
            case "and":
                c = a && b;
                break;
        }
    }
}
