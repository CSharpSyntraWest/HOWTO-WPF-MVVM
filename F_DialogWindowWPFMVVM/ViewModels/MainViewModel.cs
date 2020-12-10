
using F_DialogWindowWPFMVVM.Utilities;
using F_DialogWindowWPFMVVM.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace F_DialogWindowWPFMVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private IDialogService _dialogService;
        private IDataService _dataService;
        private BierenViewModel _bierenVM;
        private BrouwersViewModel _brouwersVM;
        public MainViewModel()
        {
            _dialogService = new WindowDialogService();
            _dataService = new MockDataService();
            BierenVM = new BierenViewModel(_dataService,_dialogService);
            BrouwersVM = new BrouwersViewModel(_dataService);
        }

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


//private object _currentViewModel;
//public object CurrentViewModel
//{
//    get { return _currentViewModel; }
//    set { OnPropertyChanged(ref _currentViewModel, value); }
//}
