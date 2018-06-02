using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Actor : MonoBehaviour {
    public List<Condition> conditions = new List<Condition>();
    public List<Action> actions = new List<Action>();
    List<Action> elseActions = new List<Action>();
    public bool any;
    public bool repeat;
    bool invoked;
    public bool update;

    public void Start () {
        foreach (var i in (Action[])actions.ToArray().Clone()) {
            if (i.isElse) {
                elseActions.Add(i);
                actions.Remove(i);
            }
        }
    }

    public void DoUpdate() {
        if (any) {
            if (!conditions.Any(x => x.Fulfilled())) {
                invoked = false;
                return;
            }
        } else {
            if (!conditions.All(x => x.Fulfilled())) {
                invoked = false;
                return;
            }
        }
        if (repeat || !invoked) {
            invoked = true;
            foreach (var action in actions)
            {
                action.Invoke();
            }
        } else {
            foreach (var action in elseActions)
            {
                action.Invoke();
            }
        }
    }

    void Update() {
        if (update) {
            DoUpdate();
        }
    }
}
