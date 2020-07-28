using Convertor.Logic;
using Convertor.Model;
using System;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Convertor
{
    public partial class Program : Form
    {
        public Program()
        {
            //InitializeComponent();
        }
        static void Main(string[] args)
        {
            /*var xTSF = XTSFHELPER.DeserializeToObject<Testsetfile>(@"D:\ZF\SummerPractice.xtsf");
            xTSF.Prename = "Summer";
            XTSFHELPER.SerializeToXml<Testsetfile>(xTSF, @"D:\ZF\SummerPractice2.xtsf");
            */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Program());
            XTSFHELPER.CreateCalpFile();

        }
    }
}
