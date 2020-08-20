using GUIConvertor.Logic;
using GUIConvertor.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIConvertor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static String path;
        private void BUTTOON_CALP_FILE_Click(object sender, EventArgs e)
        {
            ScriptGenerator.CreateCalpFile(path);
        }

        private void BUTTON_XTSF_FILE_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                path = dialog.FileName;
            }
        }
        string[] files;
        private void button_ADD_CAPL_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    files = Directory.GetFiles(fbd.SelectedPath,"*.can");
                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }
        private void button_GEN_XTSF_Click(object sender, EventArgs e)
        {
            var xtsf = new Testsetfile();
            var ctTests = 1;
            var ctFunctions = 1;
            foreach ( var file in files)
            {
                var ConditionsDictionary = XtsfToCapl.GenerateOutputFile(file);
                xtsf.Tests.Entry.Add(new Entry() { Id = $"{ctTests++}", Enabled = "1", Name = "nume Manevra - interface input" });
                foreach (var condition in ConditionsDictionary)
                {
                    xtsf.Functions.Entry.Add(new Entry() { Id = $"{ctFunctions++}", Enabled = "1", Name = "Function " + condition.Value.Name });
                    var conditionsList = new List<Condition>() 
                    { new Condition() { Type = "Signal Write", Value = $"{condition.Value.Name} = {condition.Value.Value} [{condition.Value.Time}]" } };
                    xtsf.Dataset.Entry.Add(new Entry() { Test = $"{ctTests-1}", Function= $"{ctFunctions-1}", Condition = conditionsList } );
                }
            }
            XTSFHELPER.SerializeToXml<Testsetfile>(xtsf, @"D:\ZF\testFiles\WriteLines.xml");
        }
    }
}
