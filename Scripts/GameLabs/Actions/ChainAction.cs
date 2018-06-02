using UnityEngine;
using System.Collections;

public class ChainAction : Action {
    public Action[] actions;

    public override void Invoke() {
        foreach (var item in actions) {
            item.Invoke();
        }
    }
}
