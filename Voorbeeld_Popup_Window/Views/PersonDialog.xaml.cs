﻿using System.Windows;

namespace Voorbeeld_Popup_Window
{
    /// <summary>
    /// Interaction logic for PersonDialog.xaml
    /// </summary>
    public partial class PersonDialog : Window
    {
        public PersonDialog()
        {
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
