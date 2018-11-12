using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desktop.Connector
{
    internal interface IZakazkyConnector
    {
        Task<IEnumerable<ZakazkaModel>> GetAllByUserAsync(UzivatelModel currentUser);
    }
}