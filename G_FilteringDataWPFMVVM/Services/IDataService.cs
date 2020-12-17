﻿using G_FilteringDataWPFMVVM.Models;
using System.Collections.Generic;

namespace G_FilteringDataWPFMVVM.Services
{
    public interface IDataService
    {
        IList<Bier> GeefAlleBieren();
        IList<BierSoort> GeefAlleBierSoorten();
        IList<Brouwer> GeefAlleBrouwers();
        IList<Bier> GeefBierenVoorBrouwer(Brouwer brouwer);
        IList<Bier> VoegBierToe(Bier bier);
        void WijzigBier(Bier bier);
        IList<Bier> VerwijderBier(Bier bier);
        IList<BierSoort> VoegBierSoortToe(BierSoort biersoort);
        IList<Brouwer> VerwijderBrouwer(Brouwer selectedBrouwer);
        IList<Brouwer> VoegBrouwerToe(Brouwer brouwer);
        void WijzigBrouwer(Brouwer selectedBrouwer);
    }
}