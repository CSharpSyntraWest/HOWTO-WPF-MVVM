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
        private ObservableCollection<BierSoort> _biersoorten;
        private BierSoort _selectedBierSoort;
        private Bier _selectedBier;
        public BierenViewModel(IDataService dataService)
        {
            _dataService = dataService;
            Bieren = new ObservableCollection<Bier>(dataService.GeefAlleBieren());
            BierSoorten = new ObservableCollection<BierSoort>(dataService.GeefAlleBierSoorten());
            if(SelectedBier !=null) SelectedBierSoort = SelectedBier.BierSoort;
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
        public ObservableCollection<BierSoort> BierSoorten
        {
            get { return _biersoorten; }
            set { OnPropertyChanged(ref _biersoorten, value); }
        }
        public BierSoort SelectedBierSoort
        {
            get { return _selectedBierSoort; }
            set { OnPropertyChanged(ref _selectedBierSoort, value); }
        }
    }
}
