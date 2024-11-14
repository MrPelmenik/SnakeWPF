using System;
using System.Windows.Controls;

using WPF_MVVM.Commands.Base;
using WPF_MVVM.ViewModels.Base;

namespace WPF_MVVM.Commands
{
    public class NavigationCommand : BaseCommand
    {
        private readonly Action beforeExecute;
        private readonly Action<Page, Uri> execute;
        private readonly Uri uri;

        public NavigationCommand(Action beforeExecute, Action<Page, Uri> execute, Uri uri)
        {
            this.beforeExecute = beforeExecute;
            this.execute = execute;
            this.uri = uri;
        }
        public override void Execute(object parameter)
        {
            beforeExecute?.Invoke();
            execute.Invoke((Page) parameter, uri);
        }
    }
}
