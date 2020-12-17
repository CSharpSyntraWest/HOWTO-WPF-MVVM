using System;
using System.Collections.Generic;
using System.Text;

namespace G_FilteringDataWPFMVVM.Services
{
    public interface IDialogWindow
    {
        bool? DialogResult { get; set; }
        object DataContext { get; set; }
        bool? ShowDialog();
    }
}
