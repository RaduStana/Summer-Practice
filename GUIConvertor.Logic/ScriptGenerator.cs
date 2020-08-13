using GUIConvertor.Logic.Interfaces;
using GUIConvertor.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GUIConvertor.Logic
{
    public class ScriptGenerator
    {
        const string startText = "/*@!Encoding:1252*/\nincludes\n{\n}\nvariabels\n{\n";
        private static int CountValidCondition(Testsetfile xTSF, string testCase)
        {
            int ctor = 0;
            foreach (Entry entry in xTSF.Dataset.Entry.Where(e => e.Test.Equals(testCase)))
            {
                foreach (Condition condition in entry.Condition)
                {
                    if (condition.Type.Equals("Signal write") || condition.Type.Equals("Diag Script"))
                    {
                        ctor++;
                    }
                }
            }
            return ctor;
        }
        public static void GenerateOutFile(Testsetfile xTSF, string testCase, string path,string text)
        {
            var pathVar = Path.Combine(path, Path.GetFileNameWithoutExtension(xTSF.Prename));
            if (!Directory.Exists(pathVar))
                Directory.CreateDirectory(pathVar);
            System.IO.File.WriteAllText(Path.Combine(pathVar, testCase + ".can"), text);
        }
        private static Boolean CheckDiagScript(Testsetfile xTSF, string testCase)
        {
            foreach (Entry entry in xTSF.Dataset.Entry.Where(e => e.Test.Equals(testCase)))
            {
                foreach (Condition condition in entry.Condition)
                {
                    if (condition.Type.Equals("Diag Script"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static void GenerateCapl(Testsetfile xTSF, string testCase,string path)
        {
            double result;
            int c = 0;
            List <string> auxString = new List<string>();
            string text = startText;
            if(CheckDiagScript(xTSF,testCase))
                text += "\tDiagRequest req;\n\tlong ret;\n";
            for (int i = 0; i < CountValidCondition(xTSF, testCase); i++) {
                text += $"\tmsTimer t{i};\n";
            }
            text += $"}}\non start\n{{";
            foreach (Entry entry in xTSF.Dataset.Entry.Where(e => e.Test.Equals(testCase)))
            {
                foreach (Condition condition in entry.Condition)
                {
                    var ScriptType = CaplConditionFactory.GetScript(condition);
                    if(ScriptType != null)
                    {
                        if (Double.TryParse(ScriptType.Time, out result))
                        {
                            text += $"\n\tsetimer(t{c++}, {result * 1000} );";
                        }
                        auxString.Add(ScriptType.ScriptText);
                    }
                }
            }
            text += "\n}";
            foreach(var item in auxString)
            {
                text += $"\non timer t{auxString.IndexOf(item)}\n{{" + item + "}";
            }
            GenerateOutFile(xTSF, testCase, path, text);
        }
        public static void CreateCalpFile(string path)
        {
            var xTSF = XTSFHELPER.DeserializeToObject<Testsetfile>(path);
            foreach (var test in xTSF.Tests.Entry)
            {
                GenerateCapl(xTSF, test.Id, Path.GetDirectoryName(path));
            }
        }
    }
}
