﻿using D_BindingCommandsWPFMVVM.Models;
using System.Collections.Generic;

namespace D_BindingCommandsWPFMVVM.Services
{
    public interface IDataService
    {
        IList<Bier> GeefAlleBieren();
        IList<BierSoort> GeefAlleBierSoorten();
        IList<Brouwer> GeefAlleBrouwers();
        IList<Bier> VoegBierToe(Bier bier);
        void WijzigBier(Bier bier);
        IList<Bier> VerwijderBier(Bier bier);
    }
}