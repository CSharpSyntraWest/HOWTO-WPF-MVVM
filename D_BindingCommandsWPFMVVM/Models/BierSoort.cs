﻿using D_BindingCommandsWPFMVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_BindingCommandsWPFMVVM.Models
{
    public class BierSoort : ObservableObject
    {

        private int _soortNr;
        private string _soortNaam;

        public int SoortNr { get { return _soortNr; } set { OnPropertyChanged(ref _soortNr, value); } }
        public string SoortNaam { get { return _soortNaam; } set { OnPropertyChanged(ref _soortNaam, value); } }
    }
}
