using E_ValueConverterWPFMVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_ValueConverterWPFMVVM.Models
{
    public class BierSoort : ObservableObject
    {

        private int _soortNr;
        private string _soortNaam;

        public int SoortNr { get { return _soortNr; } set { OnPropertyChanged(ref _soortNr, value); } }
        public string SoortNaam { get { return _soortNaam; } set { OnPropertyChanged(ref _soortNaam, value); } }
    }
}
