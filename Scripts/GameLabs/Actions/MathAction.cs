using UnityEngine;
using System.Collections;

public class MathAction : Action
{
    public Component script;
    public string property;
    public string expression;

    public override void Invoke () {
        float val = (float)CopyAction.Unravel(script, property).GetValue(script);
        string exp = ((string)expression.Clone()).Replace("x", val.ToString());
        float toSet = (float)new System.Xml.XPath.XPathDocument
     (new System.IO.StringReader("< r />")).CreateNavigator().Evaluate
     (string.Format("number({0})", new
     System.Text.RegularExpressions.Regex(@"([\+\-\*])").Replace(exp, " ${1} ").Replace("/", " div ").Replace("%", " mod ")));
        CopyAction.Unravel(script, property).SetValue(script, toSet);
    }
}
