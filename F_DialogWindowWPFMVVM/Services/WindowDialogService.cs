using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace F_DialogWindowWPFMVVM.Services
{
    public class WindowDialogService : IDialogService
    {
        public string OpenFile(string filter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = filter;
            if (dialog.ShowDialog() == true)
                return dialog.FileName;
            return null;
        }
    }
}
