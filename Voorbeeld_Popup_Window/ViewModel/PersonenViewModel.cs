using Voorbeeld_Popup_Window.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using Voorbeeld_Popup_Window.Services;
using Voorbeeld_Popup_Window.Utilities;

namespace Voorbeeld_Popup_Window.ViewModel
{
    public class PersonenViewModel:ObservableObject
    {
        private IDialogVisitor _visitor;
        private Persoon _selectedPersoon;
    
        public PersonenViewModel(IDialogVisitor visitor)
        {
            _visitor = visitor;
            Personen = new ObservableCollection<Persoon>();
            Personen.Add(new Persoon() { Voornaam="Jan", Familienaam="Jansen",Email="jj@hotmail.com"} );//Deze gegevens moeten uit MockDataservice komen
            //PersonListView = CollectionViewSource.GetDefaultView(Personen);
            CreatePersoonCommand = new RelayCommand(parm => VoegPersoonToe(), null);
            UpdatePersoonCommand = new RelayCommand(parm => WijzigPersoon(), p => SelectedPersoon != null);
            DeletePersoonCommand = new RelayCommand(parm => VerwijderPersoon(), p => SelectedPersoon != null);
        }
        public Persoon SelectedPersoon
        {
            get { return _selectedPersoon; }
            set { OnPropertyChanged(ref _selectedPersoon, value); }
        }
        /// <summary>

        //public ICollectionView PersonListView { get; private set; }

        public ObservableCollection<Persoon> Personen { get; set; }
        public ICommand CreatePersoonCommand { get; private set; }

        public ICommand UpdatePersoonCommand { get; private set; }
        public ICommand DeletePersoonCommand { get; private set; }
        public void VoegPersoonToe()
        {
            if (_visitor == null) return;

            Persoon p = new Persoon();
            _visitor.DynamicVisit(p);
            Personen.Add(p);  //voeg nog toe aan MockDataservice 
        }

        public void WijzigPersoon()
        {
            _visitor?.DynamicVisit(SelectedPersoon); ////wijzig nog Persoon via MockDataservice 
        }

        public void VerwijderPersoon()
        {
            if(Personen.Count > 0)
            Personen.Remove(SelectedPersoon); ////Verwijder nog Persoon via MockDataservice 
        }



    }
}
