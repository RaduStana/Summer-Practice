using Convertor.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;

namespace Convertor.Logic
{
    public class CaplToXTSF
    {
        private static double StringToDouble(string s)
        {
            double result;
            if (double.TryParse(s, out result))
            {
                return result / 1000;
            }
            return 0;
        }
        public static Dictionary<string, ConditionVariables> GenerateOutputFile(string path)
        {
            string[] Lines = System.IO.File.ReadAllLines(path);
            int ct = 0;
            Dictionary<string, ConditionVariables> DicTimeValue = new Dictionary<string, ConditionVariables>();

            foreach (string line in Lines)
            {
                if (line.Contains("setTimer"))
                {
                    string TimeValue_Pattern = @"(t[0-9]),([0-9]+)";
                    Match matchTimeValue = Regex.Match(line, TimeValue_Pattern);
                    DicTimeValue.Add(matchTimeValue.Groups[1].Value, new ConditionVariables() { Time = StringToDouble(matchTimeValue.Groups[2].Value) });
                }
                if (line.Contains("setSignal"))
                {
                    string SetSignal_Pattern = "\"(.+)\",(\\d+)";
                    Match matchSetSignal = Regex.Match(line, SetSignal_Pattern);
                    if(matchSetSignal.Success)
                    {
                        DicTimeValue[$"t{ct}"].Name = matchSetSignal.Groups[1].Value;
                        DicTimeValue[$"t{ct}"].Value = matchSetSignal.Groups[2].Value;
                    }
                    DicTimeValue[$"t{ct}"].ConditionType = Model.enums.ConditionType.SignalWrite;
                    ct++;
                }
                if (line.Contains("testWaitForDiagRequestSent"))
                {
                    DicTimeValue[$"t{ct}"].ConditionType = Model.enums.ConditionType.DiagScript;
                    ct++;
                }
                if(line.Contains("byte"))
                {
                    string sir = "";
                    string Hex_Pattern = @"(x)([0-9A-F]{2})";
                    Match matchHexValue = Regex.Match(line, Hex_Pattern , RegexOptions.IgnoreCase);
                    while(matchHexValue.Success)
                    {
                        sir += matchHexValue.Groups[2].Value + " ";
                        matchHexValue = matchHexValue.NextMatch();
                    }
                    DicTimeValue[$"t{ct}"].Value += sir + "#WAIT ";
                }
            }
            return DicTimeValue;
        }
    }
}
