using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Reflection;

public enum VarType {
    boolType,
    stringType,
    floatType
}

public class CopyAction : Action {

    public Component copyFrom;
    public string pathFrom;
    public Component copyTo;
    public string pathTo;

    public override void Invoke() {
        FieldInfo fromInfo = Unravel(copyFrom, pathFrom);
        FieldInfo toInfo = Unravel(copyTo, pathTo);
        toInfo.SetValue(copyTo, fromInfo.GetValue(copyFrom));
    }

    public static FieldInfo Unravel (object obj, string path) {
        string[] pathDot = path.Split('.');
        FieldInfo info = obj.GetType().GetField(pathDot[0]);
        if (pathDot.Count() > 0) {
            return Unravel(info.GetValue(obj), String.Join(".", pathDot.Skip(1).ToArray()));
        }
        return info;
    }
}
