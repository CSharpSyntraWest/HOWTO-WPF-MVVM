using B_MockDataServiceWPFMVVM.Models;
using B_MockDataServiceWPFMVVM.Services;
using B_MockDataServiceWPFMVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace B_MockDataServiceWPFMVVM.ViewModels
{
    public class BierenViewModel:ObservableObject
    {
        private IDataService _dataService;
        private ObservableCollection<Bier> _bieren;
        private Bier _selectedBier;
        public BierenViewModel(IDataService dataService)
        {
            _dataService = dataService;
            Bieren = new ObservableCollection<Bier>(dataService.GeefAlleBieren());
        }
        public ObservableCollection<Bier> Bieren {
            get { return _bieren; }
            set { OnPropertyChanged(ref _bieren, value); }
        }

        public Bier SelectedBier
        {
            get { return _selectedBier; }
            set { OnPropertyChanged(ref _selectedBier, value); }
        }
    }
}
