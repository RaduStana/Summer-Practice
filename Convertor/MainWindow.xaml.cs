using Convertor.Logic;
using Convertor.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Convertor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static String path;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = dialog.FileName;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ScriptGenerator.CreateCalpFile(path);
        }

        string[] files;

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    files = Directory.GetFiles(fbd.SelectedPath, "*.can");
                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var xtsf = new Testsetfile();
            var ctTests = 1;
            var ctFunctions = 1;
            foreach (var file in files)
            {
                var ConditionsDictionary = XtsfToCapl.GenerateOutputFile(file);
                xtsf.Tests.Entry.Add(new Entry() { Id = $"{ctTests++}", Enabled = "1", Name = "nume Manevra - interface input" });
                foreach (var condition in ConditionsDictionary)
                {
                    xtsf.Functions.Entry.Add(new Entry() { Id = $"{ctFunctions++}", Enabled = "1", Name = "Function " + condition.Value.Name });
                    var conditionsList = new List<Model.Condition>()
                    { new Model.Condition() { Type = "Signal Write", Value = $"{condition.Value.Name} = {condition.Value.Value} [{condition.Value.Time}]" } };
                    xtsf.Dataset.Entry.Add(new Entry() { Test = $"{ctTests - 1}", Function = $"{ctFunctions - 1}", Condition = conditionsList });
                }
            }
            XTSFHELPER.SerializeToXml<Testsetfile>(xtsf, @"D:\ZF\testFiles\WriteLines.xml");
        }
    }
}
