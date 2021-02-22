using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PingWPF_Übung
{
    public class Command : ICommand
    {
        /// <summary>
        /// Defines the action Action..
        /// </summary>
        private Action<object> _action;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="action">The action what to do.</param>
        public Command(Action<object> action)
        {
            _action = action;
        }

        /// <summary>
        /// Defines the CanExecuteChanged Event handler.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// The CanExecute boolean.
        /// </summary>
        /// <param name="parameter">The parameter if its valid.</param>
        /// <returns>If it can be executed.</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// The execution method.
        /// </summary>
        /// <param name="parameter">The parameter for executing.</param>
        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
