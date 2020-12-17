using System;
using System.Collections.Generic;
using System.Text;

namespace G_FilteringDataWPFMVVM.Services
{
    public interface IDialogService
    {
        T OpenDialog<T>(DialogViewModelBase<T> viewModel);
    }
}
