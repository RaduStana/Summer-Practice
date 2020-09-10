using Convertor.Logic;
using Convertor.Model;
using Convertor.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Convertor.ViewModels
{
    public class CAPLviewModel : BindableBase
    {
        string[] files;
        public ICommand AddCaplCommand { get; }
        public ICommand GenerateXTSFCommand { get; }
        public static CAPLviewModel Instance { get; } = new CAPLviewModel();
        public string bla;

        public CAPLviewModel()
        {
            AddCaplCommand = new ViewModelCommands(ButtonAddCapl);
            GenerateXTSFCommand = new ViewModelCommands(ButtonGenerateXTSF);
        }

        private void ButtonAddCapl()
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

        private void ButtonGenerateXTSF()
        {
            var xtsf = new Testsetfile();
            var ctTests = 1;
            var ctFunctions = 1;
            foreach (var file in files)
            {
                var ConditionsDictionary = XtsfToCapl.GenerateOutputFile(file);
                xtsf.Tests.Entry.Add(new Entry() { Id = $"{ctTests++}", Name = "nume Manevra - interface input" });
                foreach (var condition in ConditionsDictionary)
                {
                    if (condition.Value.ConditionType.Equals(Model.enums.ConditionType.DiagScript))
                        condition.Value.Name = "NAME";
                    xtsf.Functions.Entry.Add(new Entry() { Id = $"{ctFunctions++}", Name = "Function " + condition.Value.Name });
                    var conditionsList = new List<Model.Condition>()
                    { new Model.Condition() { Type = $"{condition.Value.ConditionType}", Value = $"{condition.Value.Name} = {condition.Value.Value} [{condition.Value.Time}]" } };
                    xtsf.Dataset.Entry.Add(new Entry() { Test = $"{ctTests - 1}", Function = $"{ctFunctions - 1}", Condition = conditionsList });
                }
            }
            XTSFHELPER.SerializeToXml<Testsetfile>(xtsf, @"D:\ZF\testFiles\WriteLines.xml");
        }
    }
}
