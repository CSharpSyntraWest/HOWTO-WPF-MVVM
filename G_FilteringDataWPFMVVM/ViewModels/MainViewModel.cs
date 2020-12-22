
using G_FilteringDataWPFMVVM.Utilities;
using G_FilteringDataWPFMVVM.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using G_FilteringDataWPFMVVM.Utilities;
using System.Diagnostics;


namespace G_FilteringDataWPFMVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private IDialogService _dialogService;
        private IDataService _dataService;
        private BierenViewModel _bierenVM;
        private BrouwersViewModel _brouwersVM;


        public MainViewModel()
        {
            _dialogService = new DialogService();
            _dataService = new MockDataService();
            BierenVM = new BierenViewModel(_dataService, _dialogService);
            BrouwersVM = new BrouwersViewModel(_dataService, _dialogService);
            AlertCommand = new RelayCommand(ShowAlert);
            YesNoCommand = new RelayCommand(ShowYesNoDialog);
            OpenBrouwerDetailsCommand = new RelayCommand(ShowBrouwerDetailsDialog);
            ShowWebSiteDialogCommand = new RelayCommand(ShowWebSiteDialog);
         }


        public ICommand ShowWebSiteDialogCommand { get; private set; }
        private void ShowWebSiteDialog()
        {
            Process.Start(Constants.IE_path, BierenVM.SelectedBier.WebSite);//"https://www.google.be");
        }
        private void ShowBrouwerDetailsDialog()
        {
            DialogViewModelBase<DialogResults> dialog;
            if (BrouwersVM.SelectedBrouwer != null)
            {
                dialog = new BrouwerDetailsDialogViewModel("Brouwer Details", BrouwersVM.SelectedBrouwer);
            }
            else
            {
                dialog = new AlertDialogViewModel("Brouwer Details", "Selecteer een Brouwer aub!");
            }
            DialogResults result = _dialogService.OpenDialog(dialog);
            Debug.WriteLine(result);
        }

        private void ShowYesNoDialog()
        {
            YesNoDialogViewModel dialog = new YesNoDialogViewModel("JaOfNeen", "Klik ja of neen");
            DialogResults result = _dialogService.OpenDialog(dialog);
            Debug.WriteLine(result);
        }

        private void ShowAlert()
        {
            AlertDialogViewModel dialog = new AlertDialogViewModel("Opgelet", "Waarschuwing!");
            DialogResults result = _dialogService.OpenDialog(dialog);
            Debug.WriteLine(result);
        }

        public ICommand AlertCommand { get; private set; }
        public ICommand YesNoCommand { get; private set; }
        public ICommand OpenBrouwerDetailsCommand { get; private set; }

        public BierenViewModel BierenVM
        {
            get { return _bierenVM; }
            set { OnPropertyChanged(ref _bierenVM, value); }
        }
        public BrouwersViewModel BrouwersVM
        {
            get { return _brouwersVM; }
            set { OnPropertyChanged(ref _brouwersVM, value); }
        }
    }
}



