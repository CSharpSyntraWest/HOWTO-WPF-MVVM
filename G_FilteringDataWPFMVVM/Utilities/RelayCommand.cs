using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace G_FilteringDataWPFMVVM.Utilities
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute = null;
        private readonly Func<T, bool> _canExecute = null;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute ?? (_ => true);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) => _canExecute((T)parameter);

        public void Execute(object parameter) => _execute((T)parameter);
    }

    public class RelayCommand_ : RelayCommand<object>
    {
        public RelayCommand_(Action execute)
            : base(_ => execute()) { }

        public RelayCommand_(Action execute, Func<bool> canExecute)
            : base(_ => execute(), _ => canExecute()) { }
    }



    public class RelayCommand2 : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand2(Action<object> ex) : this(ex, null) { }
        public RelayCommand2(Action<object> ex, Predicate<object> ce)
        {
            _execute = ex ?? throw new ArgumentNullException("execute");
            _canExecute = ce;
        }


        public bool CanExecute(object parm) => _canExecute == null ? true : _canExecute(parm);

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parm) => _execute(parm);
    }
}
