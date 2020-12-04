
using D_BindingCommandsWPFMVVM.Utilities;
using D_BindingCommandsWPFMVVM.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_BindingCommandsWPFMVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private IDataService _dataService;
        private BierenViewModel _bierenVM;
        public MainViewModel()
        {
            _dataService = new MockDataService();
            BierenVM = new BierenViewModel(_dataService);

        }
        public BierenViewModel BierenVM
        {
            get { return _bierenVM; }
            set { OnPropertyChanged(ref _bierenVM, value); }
        }
    }
}


//private object _currentViewModel;
//public object CurrentViewModel
//{
//    get { return _currentViewModel; }
//    set { OnPropertyChanged(ref _currentViewModel, value); }
//}
