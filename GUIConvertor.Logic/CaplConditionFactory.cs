using GUIConvertor.Logic.Conditions;
using GUIConvertor.Logic.Interfaces;
using GUIConvertor.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUIConvertor.Logic
{
    public class CaplConditionFactory
    {
        public static IConditionCapl GetScript(Condition condition)
        {
            IConditionCapl ScriptType = null;
            if (condition.Type.Equals("Signal write"))
            {
                ScriptType = new SignalWriteCapl();
                ScriptType.GenerateScriptText(condition.Value);
            }
            else if (condition.Type.Equals("Diag Script"))
            {
                ScriptType = new DiagScriptCapl();
                ScriptType.GenerateScriptText(condition.Value);
            }
            return ScriptType;
        }
    }
}
