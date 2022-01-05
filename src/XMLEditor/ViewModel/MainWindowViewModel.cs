using System;
using System.Windows.Input;

namespace XMLEditor
{
    internal class MainWindowViewModel
    {
        public Action CloseAction { get; set; }

        private ICommand _closeAppCommand;

        public ICommand CloseAppCommand
        {
            get
            {
                return _closeAppCommand ?? (_closeAppCommand = new CommandHandler(() => CloseWindow(), () => CanExecute));
            }
        }

        public bool CanExecute
        {
            get => CloseAction != null;
        }

        public void CloseWindow()
        {
            CloseAction();
        }
    }
}