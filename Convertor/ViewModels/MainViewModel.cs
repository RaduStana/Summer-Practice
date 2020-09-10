using Convertor.ViewModels.Commands;
using Convertor.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Convertor.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public ICommand XTSFCommand { get; }
        public ICommand CaplCommand { get; }
        public object CurrentView { get; set; }
        public static MainViewModel Instance { get; } = new MainViewModel();

        public MainViewModel()
        {
            XTSFCommand = new ViewModelCommands(XTSFComm);
            CaplCommand = new ViewModelCommands(CaplComm);
        }

        public void XTSFComm()
        {
            CurrentView = new XTSFview();
            OnPropertyChanged("CurrentView");
        }

        public void CaplComm()
        {
            CurrentView = new CAPLview();
            OnPropertyChanged("CurrentView");
        }
    }
}
