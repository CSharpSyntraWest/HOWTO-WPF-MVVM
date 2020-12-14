using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using F_DialogWindowWPFMVVM.Services;
using F_DialogWindowWPFMVVM.Utilities;

namespace F_DialogWindowWPFMVVM.ViewModels
{
    public class YesNoDialogViewModel : DialogViewModelBase<DialogResults>
    {
        public ICommand YesCommand { get; private set; }
        public ICommand NoCommand { get; private set; }

        public YesNoDialogViewModel(string title, string message) : base(title, message)
        {
            YesCommand = new RelayCommand<IDialogWindow>(Yes);
            NoCommand = new RelayCommand<IDialogWindow>(No);
        }

        private void Yes(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResults.Yes);
        }

        private void No(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResults.No);
        }
    }
}
