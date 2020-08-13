using System;
using System.Collections.Generic;
using System.Text;

namespace GUIConvertor.Logic.Interfaces
{
    public interface IConditionCapl
    {
        String ScriptText { get; }
        String Time { get; }
        void GenerateScriptText(string conditionValue);
    }
}
