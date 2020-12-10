using F_DialogWindowWPFMVVM.Models;
using F_DialogWindowWPFMVVM.Services;
using F_DialogWindowWPFMVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace F_DialogWindowWPFMVVM.ViewModels
{
    public class BierenViewModel:ObservableObject
    {
        private IDialogService  _dialogService;
        private IDataService _dataService;
        private ObservableCollection<Bier> _bieren;
        private ObservableCollection<BierSoort> _biersoorten;
        private ObservableCollection<Brouwer> _brouwers;
        private BierSoort _selectedBierSoort;
        private Brouwer _selectedBrouwer;
        private Bier _selectedBier;
        public BierenViewModel(IDataService dataService, IDialogService dialogService)
        {
            _dialogService = dialogService;
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
            BrowseImageCommand = new RelayCommand(BrowseImage);
        }

        private void BrowseImage()
        {
            string filepad = _dialogService.OpenFile("Image Files (*.gif;*.png;*.jpg)|*.gif;*.png;*.jpg");
            
            string appPath = Environment.CurrentDirectory;
            FileInfo fileInfo = new FileInfo(filepad);
            string filename = fileInfo.Name;
            File.Copy(filepad, Path.Combine(appPath + "\\Images", filename));
            SelectedBier.ImagePad = filename;
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
        public ICommand BrowseImageCommand { get; private set; }
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
