using F_DialogWindowWPFMVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace F_DialogWindowWPFMVVM.Models
{
    public class Bier : ObservableObject
    {
        private const string defaultImagePath = "pack://siteoforigin:,,,/Images/";
        private int _bierNr;
        private string _naam;
        private double? _alcohol;
        private Brouwer _brouwer;
        private BierSoort _bierSoort;
        public int BierNr { get { return _bierNr; } set { OnPropertyChanged(ref _bierNr, value); } }
        public string Naam { get { return _naam; } set { OnPropertyChanged(ref _naam, value); } }
        public double? Alcohol { get { return _alcohol; } set { OnPropertyChanged(ref _alcohol, value); } }
        public Brouwer Brouwer
        {
            get { return _brouwer; }
            set
            {
                OnPropertyChanged(ref _brouwer, value);
            }
        }
        public BierSoort BierSoort
        {
            get { return _bierSoort; }
            set
            {
                OnPropertyChanged(ref _bierSoort, value);
            }
        }
        private string _imagePad;
        public string ImagePad {
            get { return defaultImagePath + _imagePad; }
            set
            {
                
                OnPropertyChanged(ref _imagePad, value);
            }
        }
    }
}

