using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Convertor.Views
{
    /// <summary>
    /// Interaction logic for DiagscriptView.xaml
    /// </summary>
    public partial class DiagscriptView : UserControl
    {
        public DiagscriptView()
        {
            InitializeComponent();
            ResponseComboBox.ItemsSource = new List<string>() { "positive", "negative" };
        }

        //public string ResponseCombo
        //{
        //    get => responseCombo;
        //    set
        //    {
        //        if (responseCombo != value)
        //            responseCombo = value;
        //        //OnPropertyChanged();
        //    }
        //}
        //private string responseCombo;
        public string ScriptName { get => ScriptNameTextBox.Text; }
        public string Response { get => ResponseComboBox.Text; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
