using Convertor.Logic;
using Convertor.Model;
using Convertor.ViewModels.Commands;
using Convertor.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Convertor.ViewModels
{
    public class CAPLviewModel : BindableBase, IDataErrorInfo
    {
        string[] files;
        public ICommand AddCaplCommand { get; }
        public ICommand GenerateXTSFCommand { get; }
        public static CAPLviewModel Instance { get; } = new CAPLviewModel();
        private string testsMan;
        public string Error { get { return null; } }
        public Dictionary<string, string> ErrorCol { get; private set; } = new Dictionary<string, string>();
        public string this[string Name]
        {
            get
            {
                string result = null;
                switch (Name)
                {
                    case "Tester":
                        if (string.IsNullOrWhiteSpace(tester))
                            result = "Tester cannot be empty";
                        break;
                    case "PrenameXtsf":
                        if (string.IsNullOrWhiteSpace(prenameXtsf))
                            result = "Xtsf prename cannot be empty";
                        if (PrenameXtsf?.Length < 2)
                            result = "Must be a minimun of 2 chars";
                        break;
                    case "Email":
                        if (string.IsNullOrWhiteSpace(email))
                            result = "Email cannot be empty";
                        if (!Helper.IsValidEmail(email))
                            result = "Email has not a correct content";
                        break;
                    case "Subsystem":
                        if (string.IsNullOrWhiteSpace(subsystem))
                            result = "Subsystem cannot be empty";
                        break;
                }
                if (ErrorCol.ContainsKey(Name))
                    ErrorCol[Name] = result;
                else if (result != null)
                    ErrorCol.Add(Name, result);
                OnPropertyChanged("ErrorCOL");
                return result;
            }
        }
        public CAPLviewModel()
        {
            AddCaplCommand = new ViewModelCommands(ButtonAddCapl);
            //GenerateXTSFCommand = new ViewModelCommands(ButtonGenerateXTSF,IsClickedAdd);
            GenerateXTSFCommand = new ViewModelCommands(ButtonGenerateXTSF, IsClickedAdd);
        }
        private bool IsClickedAdd(object o)
        {
            if (files == null) return false;
            return files.Any();
        }
        public string Tester 
        { 
            get => tester; 
            set 
            {
                if(tester != value)
                    tester = value;
                OnPropertyChanged();
            }
        }
        private string tester;
        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                    email = value;
                OnPropertyChanged();
            }
        }
        private string email;
        public string PrenameXtsf
        {
            get => prenameXtsf;
            set
            {
                if (prenameXtsf != value)
                    prenameXtsf = value;
                OnPropertyChanged();
            }
        }
        private string prenameXtsf;
        public string Subsystem
        {
            get => subsystem;
            set
            {
                if (subsystem != value)
                    subsystem = value;
                OnPropertyChanged();
            }
        }
        private string subsystem;
        private ObservableCollection<string> sourceTestMode = new ObservableCollection<string>() { "Oficial test" , "Debug test" };
        public ObservableCollection<string> SourceTestMode 
        { 
            get => sourceTestMode; 
            set 
            { 
                sourceTestMode = value;
            } 
        }
        public string TestMode
        {
            get => testMode;
            set
            {
                if (testMode != value)
                    testMode = value;
                OnPropertyChanged();
            }
        }
        private string testMode;
        private ObservableCollection<string> sourceMan = new ObservableCollection<string>() { "ABS_asphalt_100kph_1", "CL_BaseTemplate_10s", "CL_BaseTemplate_30s", "YIB_StandStill_10s", "YIB_StandStill_100s", "TC_asphalt_40kph" };
        public ObservableCollection<string> SourceMan
        {
            get => sourceMan;
            set
            {
                sourceMan = value;
            }
        }
        public string TestsMan
        {
            get => testsMan;
            set
            {
                if (testsMan != value)
                    testsMan = value;
                OnPropertyChanged();
            }
        }
        FolderBrowserDialog fbd;
        private void ButtonAddCapl()
        {
            using ( fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    files = Directory.GetFiles(fbd.SelectedPath, "*.can");
                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }
        private DiagscriptView DiagScript(int ctTests)
        {
            var diagScriptView = new DiagscriptView();
            Window window = new Window()
            {
                Content = diagScriptView,
                Title = $"Diag Script TestCase {ctTests - 1}",
                Height = 150,
                Width = 300
            };
            try
            {
                window.ShowDialog();
            }
            catch
            {
                System.Windows.MessageBox.Show("Diag Script Window didn't pop-up.");
            }
            return diagScriptView;
        }
        private void ButtonGenerateXTSF()
        {
            var xtsf = new Testsetfile();
            var ctTests = 1;
            var ctFunctions = 1;
            xtsf.Information.Excelversion = new Excelversion() { Value = "ConvertorXTSFtoCAPL" };
            xtsf.Information.Email = new Email() { Value = email, EnableEmail = "yes" };
            xtsf.Information.Subsystem = new Subsystem() { Value = subsystem };
            xtsf.Information.Testmode = new Testmode() { Value = testMode };
            xtsf.Prename = prenameXtsf + ".xtsf";
            xtsf.Information.Tester = new Tester() { Value = tester };
            foreach (var file in files)
            {
                var ConditionsDictionary = CaplToXTSF.GenerateOutputFile(file);
                xtsf.Tests.Entry.Add(new Entry() { Id = $"{ctTests++}", Name = testsMan });                
                foreach (var condition in ConditionsDictionary)
                {
                    List<Model.Condition> conditionsList = null;
                    if (condition.Value.ConditionType.Equals(Model.enums.ConditionType.DiagScript))
                    {
                        var diagScriptView = DiagScript(ctTests);
                        condition.Value.Name = diagScriptView.ScriptName;
                        conditionsList = new List<Model.Condition>()
                        { new Model.Condition() { Type = $"{condition.Value.ConditionType}", Value = $"{condition.Value.Name} [{condition.Value.Time}] ({diagScriptView.Response}) = {condition.Value.Value} " } };
                    }
                    else if(condition.Value.ConditionType.Equals(Model.enums.ConditionType.SignalWrite))
                    {
                        conditionsList = new List<Model.Condition>()
                        { new Model.Condition() { Type = $"{condition.Value.ConditionType}", Value = $"{condition.Value.Name}  = {condition.Value.Value} ±0 [{condition.Value.Time}]" } };
                    }
                    xtsf.Functions.Entry.Add(new Entry() { Id = $"{ctFunctions++}", Name = "Function " + condition.Value.Name });                    
                    xtsf.Dataset.Entry.Add(new Entry() { Test = $"{ctTests - 1}", Function = $"{ctFunctions - 1}", Condition = conditionsList });
                }
            }
            XTSFHELPER.SerializeToXml<Testsetfile>(xtsf, $"{fbd.SelectedPath}" + $@"\{PrenameXtsf}.xtsf");
            System.Windows.MessageBox.Show("XTSF file has been saved!");
        }
    }
}
