using Databse;
using Models.API_Models;
using System;
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
            var firstDate = data.Min(x => DateTime.Parse(x.Datum));
            var lastDate = data.Max(x => DateTime.Parse(x.Datum));

            var kalkulace = new KalkulaceGetModel(
                data
                    .GroupBy(x => x.Zamestnanec)
                    .Select(x => new MzdoveNakladyGetModel(firstDate, lastDate, x.Key, x.Select(y => new ZaznamDochazkyGetModel(y.Datum, (y.Odchod - y.Prichod).TotalHours)).ToList(), x.First().Sazba)));

            return Ok(kalkulace);
        }
    }
}