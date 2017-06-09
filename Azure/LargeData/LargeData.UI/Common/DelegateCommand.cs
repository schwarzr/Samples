using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LargeData.UI.Common
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _executed;
        private readonly Func<object, bool> _canExecute;

        public DelegateCommand(Action<object> executed, Func<object, bool> canExecute = null)
        {
            _executed = executed;
            _canExecute = canExecute;
        }

        public virtual void InvalidateExecutionState()
        {
            RaiseCanExecuteChanged();
        }

        protected virtual void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _executed(parameter);
        }
    }
}
