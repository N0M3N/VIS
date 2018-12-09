using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desktop.Connector
{
    internal interface IStavebniDenikConnector
    {
        Task<IEnumerable<StavebniDenikModel>> GetByZakazka(ZakazkaModel zakazka);

        Task<StavebniDenikModel> Add(StavebniDenikModel model);
    }

    internal class StavebniDenikConnector : BaseConnector, IStavebniDenikConnector
    {
        public Task<StavebniDenikModel> Add(StavebniDenikModel model)
        {
            return TryHttpPostAs<StavebniDenikModel, StavebniDenikModel>($"{WebApiUrl}/stavebniDenik", model);
        }

        public Task<IEnumerable<StavebniDenikModel>> GetByZakazka(ZakazkaModel zakazka)
        {
            return TryHttpGetAs<IEnumerable<StavebniDenikModel>>($"{WebApiUrl}/stavebniDenik/zakazka/" + zakazka.Id);
        }
    }
}
