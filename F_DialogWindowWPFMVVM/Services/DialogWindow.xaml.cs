﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using F_DialogWindowWPFMVVM.Services;

namespace F_DialogWindowWPFMVVM.Services
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window,IDialogWindow
    {
        public DialogWindow()
        {
            InitializeComponent();
        }
    }
}
