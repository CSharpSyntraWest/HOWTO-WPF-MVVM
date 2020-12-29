using System;
using System.Windows.Input;

namespace Voorbeeld_Popup_Window.ViewModel
{

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        /// <summary>
        /// Constructor, which does not define a CanExecute predicate
        /// </summary>
        /// <param name="execute"></param>
        public RelayCommand(Action<object> execute) : this(execute, null) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execute">Injected delegate to perform the commanded action</param>
        /// <param name="canExecute">Injected delegate, or null, to determine if the command can be executed</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null) throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Returns true if no predicate delegate is defined, 
        /// otherwise, returns the status provided by the predicate
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Provides the command action by invoking the injected delegate.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
