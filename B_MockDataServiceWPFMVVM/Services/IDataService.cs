using C_UIWXAMLWPFMVVM.Models;
using System.Collections.Generic;

namespace C_UIWXAMLWPFMVVM.Services
{
    public interface IDataService
    {
        IList<Bier> GeefAlleBieren();
        IList<BierSoort> GeefAlleBierSoorten();
        IList<Brouwer> GeefAlleBrouwers();
    }
}