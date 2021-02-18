﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PersonManager.Commands
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private readonly Action<object> execute;

        private readonly Func<object, bool> canExecute;

        public Command(Action<object> execute) : this(execute, null)
        {

        }

        public Command(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return (canExecute == null || canExecute(parameter));
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
