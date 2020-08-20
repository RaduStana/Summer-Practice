using Convertor.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GUIConvertor.Logic.Conditions
{
    public class DiagScriptCapl : IConditionCapl
    {
        public string ScriptText { get => scriptText; }
        private string scriptText;
        public string Time { get => TimeValue; }
        private string TimeValue;
        public void GenerateScriptText(string conditionValue)
        {
            string valPattern = @"\[(\d+)\]";
            int ct = 0;
            string namePattern = @"\b([0-9A-F]{2}\b\s?)+";
            var diagScriptLine = conditionValue.Split('¶');
            Match matchTimeValue = Regex.Match(conditionValue, valPattern);
            TimeValue = matchTimeValue.Groups[1].Value;
            for (int i = 0; i < diagScriptLine.Length; i++)
            {
                Match haxMatch = Regex.Match(diagScriptLine[i], namePattern);
                if (haxMatch.Success)
                {
                    List<string> rawReq = new List<string>();
                    foreach (var item in haxMatch.Value.TrimEnd().Split(' '))
                    {
                        rawReq.Add($"0x{item}");
                    }
                    scriptText += $"\n\tbyte rawRequest{ct++}[{rawReq.Count}] = {{" + String.Join(",", rawReq) + "};";
                }
            }
            for (int j = 0; j < ct; j++)
            {
                scriptText += $"\n\tdiagSetPrimitiveData(req, rawRequest{j}, elCount(rawRequest{j}));\n";
                scriptText += "\tDiagSendRequest(req);\n";
            }
            scriptText += "\tret = testWaitForDiagRequestSent(req, 2000);\n";
        }
    }
}
