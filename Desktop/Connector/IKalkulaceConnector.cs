using Models;
using Models.API_Models;
using System.Threading.Tasks;

namespace Desktop.Connector
{
    internal interface IKalkulaceConnector
    {
        Task<KalkulaceGetModel> GetByZakazka(ZakazkaModel zakazka);
    }
}
