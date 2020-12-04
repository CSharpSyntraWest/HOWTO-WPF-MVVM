using B_MockDataServiceWPFMVVM.Models;
using System.Collections.Generic;

namespace B_MockDataServiceWPFMVVM.Services
{
    public interface IDataService
    {
        IList<Bier> GeefAlleBieren();
        IList<BierSoort> GeefAlleBierSoorten();
        IList<Brouwer> GeefAlleBrouwers();
    }
}