using Models;
using Models.API_Models;
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
            return TryHttpPutAs<StavebniDenikPostModel, StavebniDenikModel>($"{WebApiUrl}/stavebniDenik", new StavebniDenikPostModel { Datum = model.Datum, Popis = model.Popis, ZakazkaId = model.Zakazka.Id, ZamestnanecId = model.Zamestnanec.Id });
        }

        public Task<IEnumerable<StavebniDenikModel>> GetByZakazka(ZakazkaModel zakazka)
        {
            return TryHttpGetAs<IEnumerable<StavebniDenikModel>>($"{WebApiUrl}/stavebniDenik/zakazka/" + zakazka.Id);
        }
    }
}
