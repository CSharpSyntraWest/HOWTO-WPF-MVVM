using System;
using System.Collections.Generic;
using System.Text;

namespace F_DialogWindowWPFMVVM.Services
{
    public interface IDialogWindow
    {
        bool? DialogResult { get; set; }
        object DataContext { get; set; }
        bool? ShowDialog();
    }
}
