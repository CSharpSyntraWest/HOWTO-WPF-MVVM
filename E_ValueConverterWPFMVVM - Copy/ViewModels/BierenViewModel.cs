using E_ValueConverterWPFMVVM.Models;
using E_ValueConverterWPFMVVM.Services;
using E_ValueConverterWPFMVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace E_ValueConverterWPFMVVM.ViewModels
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
            AddBierCommand = new RelayCommand(VoegBierToe);
            UpdateBierCommand = new RelayCommand(WijzigBierGegevens);
            DeleteBierCommand = new RelayCommand(VerwijderBier);
        }

        private void VerwijderBier()
        {

            Bieren = new ObservableCollection<Bier>(_dataService.VerwijderBier(SelectedBier));
            if(_bieren.Count > 0) SelectedBier = _bieren[0];
        }

        private void WijzigBierGegevens()
        {
           _dataService.WijzigBier(SelectedBier);
        }

        private void VoegBierToe()
        {
            Bier bier = new Bier() {Naam = "Nieuw Bier" , BierSoort = BierSoorten[0],Brouwer =Brouwers[0]};
            Bieren = new ObservableCollection<Bier>(_dataService.VoegBierToe(bier));
            SelectedBier = Bieren[Bieren.Count - 1];
        }

        public ICommand AddBierCommand { get; private set; }
        public ICommand UpdateBierCommand { get; private set; }
        public ICommand DeleteBierCommand { get; private set; }
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
