using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ConstructionDiary.App
{
    public class DelegateCommand : ICommand
    {
        private readonly Func<bool> _canExecute;

        private readonly Action _executed;

        public DelegateCommand(Action executed, Func<bool> canExecute = null)
        {
            _executed = executed;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            _executed();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}