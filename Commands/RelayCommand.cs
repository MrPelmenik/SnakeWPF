using System;

using WPF_MVVM.Commands.Base;

namespace WPF_MVVM.Commands
{
    public class RelayCommand : BaseCommand
    {
        private readonly Action execute;

        public RelayCommand(Action execute)
        {
            this.execute = execute;
        }

        public override void Execute(object parameter)
        {
            execute.Invoke();
        }
    }
}
