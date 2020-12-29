using System;
using System.Collections.Generic;
using System.Text;
using Voorbeeld_Popup_Window.Services;
using Voorbeeld_Popup_Window.Utilities;

namespace Voorbeeld_Popup_Window.ViewModel
{
    public class MainViewModel:ObservableObject
    {
        private IDialogVisitor _visitor;
        private PersonenViewModel _personenVM;
        public MainViewModel()
        {
            _visitor = new DialogVisitor();
            PersonenVM = new PersonenViewModel(_visitor);
        }

        public PersonenViewModel PersonenVM
        {
            get { return _personenVM; }
            set {
                OnPropertyChanged(ref _personenVM, value);
            }
        }


    }
}
