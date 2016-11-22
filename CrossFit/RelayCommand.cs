using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CrossFit.ViewModel;

namespace CrossFit
{
    public class RelayCommand : ICommand
    {
        private Action methodToExecute = null;
        //private Func<bool> _canExecute;

        public RelayCommand(Action execute)
        {
            this.methodToExecute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.methodToExecute();
        }

        public event EventHandler CanExecuteChanged;

        //public static implicit operator RelayCommand(RemoveWodCommand v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
