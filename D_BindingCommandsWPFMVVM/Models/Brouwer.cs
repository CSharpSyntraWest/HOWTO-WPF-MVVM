﻿using D_BindingCommandsWPFMVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace D_BindingCommandsWPFMVVM.Models
{
    public class Brouwer : ObservableObject
    {

        #region fields
        private int _brouwerNr;
        private string _brNaam;
        private string _straat;
        private short? _postcode;
        private string _gemeente;
        private double? _omzet;
        #endregion

        #region properties
        public int BrouwerNr { get { return _brouwerNr; } set { OnPropertyChanged(ref _brouwerNr, value); } }
        public string BrNaam { get { return _brNaam; } set { OnPropertyChanged(ref _brNaam, value); } }
        public string Straat { get { return _straat; } set { OnPropertyChanged(ref _straat, value); } }
        public short? PostCode { get { return _postcode; } set { OnPropertyChanged(ref _postcode, value); } }
        public string Gemeente { get { return _gemeente; } set { OnPropertyChanged(ref _gemeente, value); } }
        public double? Omzet { get { return _omzet; } set { OnPropertyChanged(ref _omzet, value); } }

        #endregion


    }
}
// private ObservableCollection<Bier> _bieren;
//Constructor
//public Brouwer()
//{
//    _bieren = new ObservableCollection<Bier>();
//}
//public ObservableCollection<Bier> Bieren
//{
//    get
//    {
//        return _bieren;
//    }
//    set
//    {
//        OnPropertyChanged(ref _bieren, value);
//    }
//}


