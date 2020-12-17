using G_FilteringDataWPFMVVM.Models;
using G_FilteringDataWPFMVVM.Services;
using G_FilteringDataWPFMVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace G_FilteringDataWPFMVVM.ViewModels
{
    public class BrouwersViewModel: ObservableObject
    {
        private IDialogService _dialogService;
        private IDataService _dataService;
        private ObservableCollection<Brouwer> _brouwers;
        private ObservableCollection<BierSoort> _bierSoorten;
        private Brouwer _selectedBrouwer;
        public BrouwersViewModel(IDataService dataService,IDialogService dialogService)
        {
            _dialogService = dialogService;
            _dataService = dataService;
            Brouwers = new ObservableCollection<Brouwer>(_dataService.GeefAlleBrouwers());
            BierSoorten = new ObservableCollection<BierSoort>(_dataService.GeefAlleBierSoorten());
            AddBrouwerCommand = new RelayCommand(VoegBrouwerToe);
            UpdateBrouwerCommand = new RelayCommand(WijzigBrouwerGegevens);
            DeleteBrouwerCommand = new RelayCommand(VerwijderBrouwer);
        }
        public ICommand AddBrouwerCommand { get; private set; }
        public ICommand UpdateBrouwerCommand { get; private set; }
        public ICommand DeleteBrouwerCommand { get; private set; }
        private void VerwijderBrouwer()
        {
            //Vraag bevestiging om bier te verwijderen via YesNo Dialoogvenster
            YesNoDialogViewModel dialog = new YesNoDialogViewModel("Verwijderen Brouwer", $"Bent u zeker dat u Brouwer '{SelectedBrouwer.BrNaam}' wilt verwijderen?");

            DialogResults result = _dialogService.OpenDialog(dialog);
            Debug.WriteLine(result);
            if (result == DialogResults.Yes)
            {
                Brouwers = new ObservableCollection<Brouwer>(_dataService.VerwijderBrouwer(SelectedBrouwer));
                if (_brouwers.Count > 0) SelectedBrouwer = _brouwers[0];
            }
        }

        private void WijzigBrouwerGegevens()
        {
            _dataService.WijzigBrouwer(SelectedBrouwer);
        }

        private void VoegBrouwerToe()
        {
            Brouwer brouwer = new Brouwer() { BrNaam = "Nieuwe Brouwer", Straat="NA", Gemeente="NA"  };
            Brouwers = new ObservableCollection<Brouwer>(_dataService.VoegBrouwerToe(brouwer));
            SelectedBrouwer = Brouwers[Brouwers.Count - 1];
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
