using UnityEngine;
using System.Collections;
using System.Linq;
using System.Reflection;
using System;

public enum Sign {
    less,
    equal,
    more
}

public class VariableCondition : Condition {
	
    public Component comp;
    public string path;
    public Component equal;
    public string equalTo;
    public Sign sign;

    public override bool Fulfilled () {
        switch (sign) {
            case Sign.less:
                return (float)CopyAction.Unravel(comp, path).GetValue(comp) < (float)CopyAction.Unravel(equal, equalTo).GetValue(equal);
            case Sign.equal:
                return CopyAction.Unravel(comp, path).GetValue(comp).Equals(CopyAction.Unravel(equal, equalTo).GetValue(equal));
            case Sign.more:
                return (float)CopyAction.Unravel(comp, path).GetValue(comp) > (float)CopyAction.Unravel(equal, equalTo).GetValue(equal);
        }
        return false;
    }
}
