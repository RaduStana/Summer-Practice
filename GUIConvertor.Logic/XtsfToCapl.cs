using GUIConvertor.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;

namespace GUIConvertor.Logic
{
    public class XtsfToCapl
    {
        private static double StringToDouble(string s)
        {
            double result;
            if(double.TryParse(s,out result))
            {
                return result/1000;
            }
            return 0;
        }
        static string text = "";
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
                    DicTimeValue[$"t{ct}"].Name = matchSetSignal.Groups[1].Value;
                    DicTimeValue[$"t{ct}"].Value = matchSetSignal.Groups[2].Value;
                    ct++;
                }
                if(line.Contains("testWaitForDiagRequestSent"))
                {
                    ct++;
                }
            }
            foreach (var item in DicTimeValue)
            {
                text += item.Key + " " + item.Value.Name + " " + item.Value.Time + " " + item.Value.Value + "\n";
            }
            System.IO.File.WriteAllText(@"D:\ZF\testFiles\WriteLines.txt", text);
            return DicTimeValue;
        }
    }
}
