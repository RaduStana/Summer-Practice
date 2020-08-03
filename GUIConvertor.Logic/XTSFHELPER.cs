using GUIConvertor.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace GUIConvertor.Logic
{
    public class XTSFHELPER
    {
        public static T DeserializeToObject<T>(string filepath) where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StreamReader sr = new StreamReader(filepath))
            {
                return (T)ser.Deserialize(sr);
            }
        }
        public static void SerializeToXml<T>(T anyobject, string xmlFilePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(anyobject.GetType());

            using (StreamWriter writer = new StreamWriter(xmlFilePath))
            {
                xmlSerializer.Serialize(writer, anyobject);
            }
        }
        public static void generateCalp(Testsetfile xTSF,string testCase, string fileName)
        {
            string aux = "";
            string text = "includes\n{\n}\non preStart\n{//declare system variables if needed\n}\non start\n{\n\ttestCaseManipulations();\n}\non stopMeasurement\n{\n}\nvariabels\n{\n\n\t";
            text += "DiagRequest req;\n\tlong ret;" + "\n}\nvoid testCase()\n{";
            foreach (Entry entry in xTSF.Dataset.Entry.Where(e => e.Test.Equals(testCase)))
            {
                foreach (Condition condition in entry.Condition)
                {
                    if (condition.Type.Equals("Signal write"))
                    {
                        string namePattern = @"([A-Za-z0-9._]+) = ([\d\.]+) .* \[([\d\.]+)\]";
                        Match m = Regex.Match(condition.Value, namePattern);
                        if(m.Success)
                        {
                            text += "\nif(getSignalTime(" + m.Groups[1].Value + ") >= " + m.Groups[3].Value + ")\n";
                            text += "{\n\tsetSignal(\"" + m.Groups[1].Value + "\"," + m.Groups[2].Value + ");\n}\n";
                        }
                    }
                    if (condition.Type.Equals("Diag Script"))
                    {
                        string valPattern = @"(\b\d\b)";
                        string namePattern = @"\b([0-9A-F]{2}\b\s?)+";
                        var X = condition.Value.Split('¶');
                        Match m2 = Regex.Match(condition.Value,valPattern);
                        text += $"\n\tif(getSignalTime(\"\") == {m2.Groups[1].Value})\n{{\n";
                        for (int i=0 ; i < X.Length ; i++)
                        {
                            Match m = Regex.Match(X[i], namePattern);
                            if (m.Success)
                            {
                                aux = "";
                                List<string> rawReq = new List<string>();
                                foreach (var item in m.Value.TrimEnd().Split(' '))
                                {
                                    rawReq.Add($"0x{item}");
                                }
                                foreach(var item2 in rawReq)
                                {
                                    aux += item2 + ",";
                                }
                                aux = aux.Substring(0, aux.LastIndexOf(","));
                                text += $"\tbyte rawRequest [{rawReq.Count}] = {{"  + aux + "};\n";
                            }
                        }
                        text += "\tfor ( i = 0 ; i <= {} ; i++ )\n{\n";
                        text += "\t\tdiagSetPrimitiveData(req, rawRequest, elCount(rawRequest));\n";
                        text += "\t\tDiagSendRequest(req);\n";
                        text += "\t\tret = testWaitForDiagRequestSent(req, 2000);\n}\n}";
                    }
                }
            }
            text += "\n}";
            System.IO.File.WriteAllText($@"D:\ZF\testFiles\{fileName}{testCase}.calp", text);
        }
        public static void CreateCalpFile(string path,string fileName)
        {
            var xTSF = DeserializeToObject<Testsetfile>(path);
            foreach (var test in xTSF.Tests.Entry)
            {
                generateCalp(xTSF, test.Id, fileName);
            }
        }
    }
}
