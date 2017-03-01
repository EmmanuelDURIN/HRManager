using System;
using System.Windows.Input;

namespace HRManager.ViewModel.Command
{
    public class RelayCommand : ICommand
    {
        #region Fields

        private Action<object> _execute;
        public Action<object> Action
        {
            get { return _execute; }
            set { _execute = value; }
        }
        readonly Predicate<object> _canExecute;

        #endregion // Fields

        #region Constructors
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion // Constructors

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
        public event EventHandler CanExecuteChanged;
        public void FireExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs() );
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        #endregion // ICommand Members
    }
}
