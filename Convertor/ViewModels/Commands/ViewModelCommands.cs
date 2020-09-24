using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Convertor.ViewModels.Commands
{
    public class ViewModelCommands : ICommand
    {
        private Action _execute;
        private readonly Predicate<object> _canExecute;
        public ViewModelCommands(Action execute)
        {
            _execute = execute;
        }
        public ViewModelCommands(Action execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;
            else
                return _canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}
