using F_DialogWindowWPFMVVM.Models;
using F_DialogWindowWPFMVVM.Services;
using F_DialogWindowWPFMVVM.Utilities;
using F_DialogWindowWPFMVVM.ViewModels;
using F_DialogWindowWPFMVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace F_DialogWindowWPFMVVM.ViewModels
{
    public class BierenViewModel:ObservableObject
    {
        private IFileDialogService _fileDialog;
        private IDialogService _dialogService;
        private IDataService _dataService;
        private ObservableCollection<Bier> _bieren;
        private ObservableCollection<BierSoort> _biersoorten;
        private ObservableCollection<Brouwer> _brouwers;
        private BierSoort _selectedBierSoort;
        private Brouwer _selectedBrouwer;
        private Bier _selectedBier;
        public BierenViewModel(IDataService dataService, IDialogService dialogService)
        {
            _fileDialog = new FileDialogWindow();
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
            OpenInputDialogCommand = new RelayCommand(OpenInputDialogBierSoort);
        }

        private void OpenInputDialogBierSoort()
        {
            string bierSoort =null;
            //Input Dialoogvenster tonen om een nieuwe biersoort toe te voegen
            InputDialogViewModel dialog = new InputDialogViewModel("Toevoegen biersoort", "Geef naam van biersoort:");

            var result = _dialogService.OpenDialog(dialog);
            // Debug.WriteLine(result);
            if (result != null)
            {
                if (result.ToString() != DialogResults.Cancel.ToString())
                    bierSoort = result.ToString();
            }
            if (bierSoort !=null) VoegBierSoortToe(bierSoort);
        }

        private void VoegBierSoortToe(string bierSoort)
        {
            //Dataservice aanroepen om een biersoort toe te voegen
            
            BierSoort biersoort = new BierSoort() { SoortNaam = bierSoort };
            BierSoorten = new ObservableCollection<BierSoort>(_dataService.VoegBierSoortToe(biersoort));
            SelectedBier.BierSoort = BierSoorten[BierSoorten.Count - 1];
        }

        private void BrowseImage()
        {
            var filepad = _fileDialog.OpenFile("Image Files (*.gif;*.png;*.jpg)|*.gif;*.png;*.jpg");
            if (filepad != null)
            {

                string appPath = Environment.CurrentDirectory;
                FileInfo fileInfo = new FileInfo(filepad);
                string filename = fileInfo.Name;
                string destPath = Path.Combine(appPath + "\\Images", filename);
                if(!File.Exists(destPath)) File.Copy(filepad, destPath);
                SelectedBier.ImagePad = filename;
            }
        }
        private void VerwijderBier()
        {
            //Vraag bevestiging om bier te verwijderen via YesNo Dialoogvenster
            YesNoDialogViewModel dialog = new YesNoDialogViewModel("Verwijderen Bier", $"Bent u zeker dat u Bier '{SelectedBier.Naam}' wilt verwijderen?" );

            DialogResults result = _dialogService.OpenDialog(dialog);
            Debug.WriteLine(result);
            if(result== DialogResults.Yes)
            {
                Bieren = new ObservableCollection<Bier>(_dataService.VerwijderBier(SelectedBier));
                if (_bieren.Count > 0) SelectedBier = _bieren[0];
            }         
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
        public ICommand OpenInputDialogCommand { get; private set; }
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
