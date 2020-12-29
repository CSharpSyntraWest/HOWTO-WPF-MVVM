using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Voorbeeld_Popup_Window.Utilities
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <typeparam name="T"></typeparam>
        /// <param name="field">The private variable</param>
        /// <param name="value">The new value</param>
        /// <param name="propName">Attribute generated property name</param>
        protected void OnPropertyChanged<T>(ref T field, T value,
            [CallerMemberName] string propName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
