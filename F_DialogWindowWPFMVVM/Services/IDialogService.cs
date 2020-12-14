using System;
using System.Collections.Generic;
using System.Text;

namespace F_DialogWindowWPFMVVM.Services
{
    public interface IDialogService
    {
        T OpenDialog<T>(DialogViewModelBase<T> viewModel);
    }
}
