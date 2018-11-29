using Databse;
using Models.API_Models;
using System.Linq;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class KalkulaceController : ApiController
    {
        private readonly KalkulaceEntity kalkulaceEntity;
        private readonly ZakazkaEntity zakazkaEntity;

        public KalkulaceController()
        {
            kalkulaceEntity = new KalkulaceEntity();
            zakazkaEntity = new ZakazkaEntity();
        }

        [HttpGet]
        [Route("kalkulace/{id}")]
        public IHttpActionResult GetProZakazku([FromUri] int id)
        {
            var data = kalkulaceEntity.Kalkulace(id);

            var kalkulace = new KalkulaceGetModel(
                data
                    .GroupBy(x => x.Zamestnanec)
                    .Select(x => new MzdoveNakladyGetModel(x.Key, x.Select(y => new ZaznamDochazkyGetModel(y.Datum, (y.Odchod - y.Prichod).TotalHours)), x.First().Sazba)));

            return Ok(kalkulace);
        }
    }
}