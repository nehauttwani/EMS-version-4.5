using System;
using System.Windows.Input;

namespace EMS
{
    public class RelayCommand : ICommand
    {
        Action<object> _TargetExecuteMethod;
        Func<object, bool> _TargetCanExecuteMethod;

        public RelayCommand(Action<object> executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {

            if (_TargetCanExecuteMethod != null)
            {
                return _TargetCanExecuteMethod(parameter);
            }

            if (_TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }


        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            if (_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod(parameter);
            }
        }

    }
}
