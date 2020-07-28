using Convertor.Model;
using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Serialization;

namespace Convertor.Logic
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

        public static void CreateCalpFile()
        {
            var xTSF = DeserializeToObject<Testsetfile>(@"D:\ZF\SummerPractice.xtsf");
            string text = "includes\n{\n}\nvariabels\n{\n}\nvoid testCase()\n{\n}" ;

            foreach ( Entry entry in xTSF.Hash.Entry)
            {
                foreach ( Condition condition in entry.Condition)
                {
                    if(condition.Type.Equals("signal write"))
                    {
                        string separator = "=";
                        int separatorIndex = condition.Value.IndexOf(separator);
                        if (separatorIndex >= 0)
                        {
                            string resultName = condition.Value.Substring(0,separatorIndex);
                            string resultValue = condition.Value.Substring(separatorIndex, separatorIndex+3);
                            text = text + "if(setSignal(" + resultName + "," + resultValue + ")";
                        }
                    }
                }
            }
            Console.WriteLine(text);
            System.IO.File.WriteAllText(@"D:\ZF\SummerPractice.calp", text);
        }
    }
}
