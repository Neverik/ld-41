using UnityEngine;
using System.Collections;

public class VectorAction : Action {
    public Vector3 a;
    public Vector3 b;
    public Vector3 c;
    public float cf;
    public string op;

    public override void Invoke () {
        switch (op) {
            case "plus":
                c = a + b;
                break;
            case "minus":
                c = a - b;
                break;
            case "dot":
                cf = Vector3.Dot(a, b);
                break;
            case "cross":
                c = Vector3.Cross(a, b);
                break;
            case "dist":
                cf = Vector3.Distance(a, b);
                break;
            case "norm":
                c = a.normalized;
                break;
        }
    }
}