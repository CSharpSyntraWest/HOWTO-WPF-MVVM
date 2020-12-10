using E_ValueConverterWPFMVVM.Models;
using E_ValueConverterWPFMVVM.Services;
using E_ValueConverterWPFMVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace E_ValueConverterWPFMVVM.ViewModels
{
    public class BrouwersViewModel: ObservableObject
    {
        private IDataService _dataService;
        private ObservableCollection<Brouwer> _brouwers;
        private ObservableCollection<BierSoort> _bierSoorten;
        private Brouwer _selectedBrouwer;
        public BrouwersViewModel(IDataService dataService)
        {
            _dataService = dataService;
            Brouwers = new ObservableCollection<Brouwer>(_dataService.GeefAlleBrouwers());
            BierSoorten = new ObservableCollection<BierSoort>(_dataService.GeefAlleBierSoorten());
        }
        public ObservableCollection<BierSoort> BierSoorten
        {
            get { return _bierSoorten; }
            set { OnPropertyChanged(ref _bierSoorten, value); }
        }
        public ObservableCollection<Brouwer> Brouwers
        {
            get { return _brouwers; }
            set { OnPropertyChanged(ref _brouwers, value); }
        }

        public Brouwer SelectedBrouwer
        {
            get { return _selectedBrouwer; }
            set {
                if(_selectedBrouwer !=null)  _selectedBrouwer.Bieren = new ObservableCollection<Bier>(_dataService.GeefBierenVoorBrouwer(value));
                OnPropertyChanged(ref _selectedBrouwer, value); 
                
            }
        }
    }
}
