﻿using C_UIWXAMLWPFMVVM.Models;
using C_UIWXAMLWPFMVVM.Services;
using C_UIWXAMLWPFMVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace C_UIWXAMLWPFMVVM.ViewModels
{
    public class BierenViewModel:ObservableObject
    {
        private IDataService _dataService;
        private ObservableCollection<Bier> _bieren;
        private ObservableCollection<BierSoort> _biersoorten;
        private ObservableCollection<Brouwer> _brouwers;
        private BierSoort _selectedBierSoort;
        private Brouwer _selectedBrouwer;
        private Bier _selectedBier;
        public BierenViewModel(IDataService dataService)
        {
            _dataService = dataService;
            Bieren = new ObservableCollection<Bier>(dataService.GeefAlleBieren());
            BierSoorten = new ObservableCollection<BierSoort>(dataService.GeefAlleBierSoorten());           
            if(Brouwers == null)
            {
                Brouwers = new ObservableCollection<Brouwer>(dataService.GeefAlleBrouwers());
            }
            if (SelectedBier != null)
            {
                SelectedBierSoort = SelectedBier.BierSoort;
                SelectedBrouwer = SelectedBier.Brouwer;
            }
        }
        public ObservableCollection<Brouwer> Brouwers {
            get { return _brouwers; }
            set { OnPropertyChanged(ref _brouwers, value); }
        }
        public ObservableCollection<Bier> Bieren {
            get { return _bieren; }
            set { OnPropertyChanged(ref _bieren, value); }
        }
        public Brouwer SelectedBrouwer
        {
            get { return _selectedBrouwer; }
            set { OnPropertyChanged(ref _selectedBrouwer, value); }
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
