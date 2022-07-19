namespace WpfApplication.Commands
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// RelayCommand for commands.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Predicate<object> canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="execute">Action.</param>
        /// <param name="canExecute">A predicate that determines whether a command can be executed or not.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <inheritdoc/>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <inheritdoc/>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        /// <inheritdoc/>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
