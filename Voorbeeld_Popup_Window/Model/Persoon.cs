using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Voorbeeld_Popup_Window.Utilities;

namespace Voorbeeld_Popup_Window.Model
{
    public class Persoon : ObservableObject
    {
        
        private string _voornaam;
        public string Voornaam
        {
            get { return _voornaam; }
            set { OnPropertyChanged(ref _voornaam, value); }
        }

        private string _familienaam;
        public string Familienaam
        {
            get { return _familienaam; }
            set { OnPropertyChanged(ref _familienaam, value); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { OnPropertyChanged(ref _email, value); }
        }

    }
}
