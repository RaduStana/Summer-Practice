using Convertor.Logic;
using Convertor.Model;
using System;

namespace Convertor
{
    class Program
    {
        static void Main(string[] args)
        {
            var xTSF = XTSFHELPER.DeserializeToObject<Testsetfile>(@"D:\ZF\SummerPractice.xtsf");
            xTSF.Prename = "Summer";
            XTSFHELPER.SerializeToXml<Testsetfile>(xTSF, @"D:\ZF\SummerPractice2.xtsf");
        }
    }
}
