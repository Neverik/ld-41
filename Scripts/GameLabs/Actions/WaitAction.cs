using UnityEngine;
using System.Collections;

public class WaitAction : Action {

    public Action next;
    public float delay;

    public override void Invoke () {
        Wait();
    }

    IEnumerator Wait () {
        yield return new WaitForSeconds(delay);
        next.Invoke();
    }
}
