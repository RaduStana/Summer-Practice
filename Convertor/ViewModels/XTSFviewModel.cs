using Convertor.Logic;
using Convertor.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Convertor.ViewModels
{
    public class XTSFviewModel : BindableBase
    {
        static String path;
        public ICommand AddXTSFCommand { get; }
        public ICommand GenerateCaplCommand { get; }
        public static XTSFviewModel Instance { get; } = new XTSFviewModel();

        public XTSFviewModel()
        {
            AddXTSFCommand = new ViewModelCommands(ButtonAddXTSF);
            GenerateCaplCommand = new ViewModelCommands(ButtonGenerateCAPL,IsClickedAdd);
        }
        private bool IsClickedAdd(object o)
        {
            return !String.IsNullOrWhiteSpace(path); 
        }
        private void ButtonAddXTSF()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = dialog.FileName;
            }
        }
        private void ButtonGenerateCAPL()
        {
            ScriptGenerator.CreateCaplFile(path);
            System.Windows.MessageBox.Show("Capl scripts has been saved!");
        }
    }
}
