using G_FilteringDataWPFMVVM.Models;
using G_FilteringDataWPFMVVM.Services;
using G_FilteringDataWPFMVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace G_FilteringDataWPFMVVM.ViewModels
{
    public class BrouwerDetailsDialogViewModel : DialogViewModelBase<DialogResults>
    {
        public Brouwer SelectedBrouwer { get; set; }
        public ICommand CloseCommand { get; private set; }
        public BrouwerDetailsDialogViewModel(string title, Brouwer brouwer) : base(title,  brouwer.BrNaam)
        {
            SelectedBrouwer = brouwer;
            CloseCommand = new RelayCommand<IDialogWindow>(Close);
        }
        private void Close(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResult);
        }
    }
}
