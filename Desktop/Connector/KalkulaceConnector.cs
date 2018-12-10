using Models;
using Models.API_Models;
using System.Threading.Tasks;

namespace Desktop.Connector
{
    internal class KalkulaceConnector : BaseConnector, IKalkulaceConnector
    {
        public Task<KalkulaceGetModel> GetByZakazka(ZakazkaModel zakazka)
        {
            return Task.Run(async () =>
            {
                return await TryHttpGetAs<KalkulaceGetModel>($"{WebApiUrl}/kalkulace/{zakazka.Id}");
            });
        }
    }
}
