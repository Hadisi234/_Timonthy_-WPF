using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lesson_05_MVVM.Commands
{
    internal class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (this.ExecuteFunc == null)
            {
                return true;
            }
           return this.ExecuteFunc(parameter);
        }

        public void Execute(object parameter)
        {
            if (this.ExecuteAction == null)
            {
                return;
            }
            this.ExecuteAction(parameter);
        }
        public Action<object> ExecuteAction { get; set; }
        public Func<object,bool> ExecuteFunc { get; set; }
    }
}
