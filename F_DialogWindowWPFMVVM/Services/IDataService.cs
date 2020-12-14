using F_DialogWindowWPFMVVM.Models;
using System.Collections.Generic;

namespace F_DialogWindowWPFMVVM.Services
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
    }
}