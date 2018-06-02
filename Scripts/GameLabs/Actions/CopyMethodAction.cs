using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Reflection;

public class CopyMethodAction : Action {
	
    public Component copyFrom;
    public string pathFrom;
    public Component copyTo;
    public string pathTo;
    public Unraveller[] unravel;

    public override void Invoke()
    {
        FieldInfo toInfo = CopyAction.Unravel(copyTo, pathTo);
        MethodInfo fromInfo = UnravelMethod(copyFrom, pathFrom);
        toInfo.SetValue(copyTo, fromInfo.Invoke(copyFrom, unravel.Select(x => x.Unravel()).ToArray()));
    }
    MethodInfo UnravelMethod(Component objec, string path)
    {
        var obj = objec;
        FieldInfo info = CopyAction.Unravel(obj, String.Join(".", path.Split('.').Take(path.Split('.').Length-1).ToArray()));
        string lastProp = path.Split('.').Last();
        return info.GetType().GetMethod(lastProp);
    }

}