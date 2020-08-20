using Convertor.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GUIConvertor.Logic.Conditions
{
    public class SignalWriteCapl : IConditionCapl
    {
        public string ScriptText { get => scriptText; }
        public string Time { get => TimeValue; }
        private string TimeValue;
        private string scriptText;
        public void GenerateScriptText(string conditionValue)
        {
            string namePattern = @"([A-Za-z0-9._]+) = ([\d\.]+) .* \[([\d\.]+)\]";
            Match m = Regex.Match(conditionValue, namePattern);
            if (m.Success)
            {
                scriptText += "\n\tsetSignal(\"" + m.Groups[1].Value + "\"," + m.Groups[2].Value + ");\n";
                TimeValue = m.Groups[3].Value;
            }
        }
    }
}
