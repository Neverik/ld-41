using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System;

public class MethodAction : Action
{
    public Component copyFrom;
    public string pathFrom;
    public Unraveller[] unravel;

    public override void Invoke()
    {
        MethodInfo fromInfo = UnravelMethod(copyFrom, pathFrom);
        fromInfo.Invoke(copyFrom, unravel.Select(x => x.Unravel()).ToArray());
    }

    public static MethodInfo UnravelMethod(Component objec, string path) {
        var obj = objec;
        FieldInfo info = CopyAction.Unravel(obj, String.Join(".", path.Split('.').Take(path.Split('.').Length - 1).ToArray()));
        string lastProp = path.Split('.').Last();
        return info.GetType().GetMethod(lastProp);
    }

}

[System.Serializable]
public class Unraveller {
    public Component x;
    public string path;

    public FieldInfo Unravel () {
        return CopyAction.Unravel(x, path);
    }
}