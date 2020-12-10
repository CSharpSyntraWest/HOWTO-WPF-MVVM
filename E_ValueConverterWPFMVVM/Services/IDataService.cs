using E_ValueConverterWPFMVVM.Models;
using System.Collections.Generic;

namespace E_ValueConverterWPFMVVM.Services
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

    }
}