using Databse;
using Models;
using Models.API_Models;
using System;
using System.Collections.Generic;
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
            var zamestnanci = data.Select(x => x.Zamestnanec).Distinct(new UserComparer());
            var datumy = new List<DateTime>();
            for (DateTime date = firstDate; date <= lastDate; date = date.AddDays(1))
            {
                datumy.Add(date);
            }

            var naklady = new List<MzdoveNakladyGetModel>();
            foreach (var zamestnanec in zamestnanci)
            {
                var dochazka = data.Where(x => x.Zamestnanec.Id == zamestnanec.Id);
                var zaznamy = new List<ZaznamDochazkyGetModel>();

                foreach (var datum in datumy)
                {
                    var zaznam = dochazka.FirstOrDefault(x => x.Datum == datum.ToShortDateString());
                    if (zaznam == null)
                    {
                        zaznamy.Add(new ZaznamDochazkyGetModel { Datum = datum.ToShortDateString(), OdpracovanychHodin = 0 });
                    }
                    else
                    {
                        zaznamy.Add(new ZaznamDochazkyGetModel { Datum = datum.ToShortDateString(), OdpracovanychHodin = Math.Floor((zaznam.Odchod - zaznam.Prichod).TotalHours) });
                    }
                }

                naklady.Add(new MzdoveNakladyGetModel
                {
                    Zamestnanec = zamestnanec,
                    Sazba = data.First(x => x.Zamestnanec == zamestnanec).Sazba,
                    Dochazka = zaznamy.ToArray()
                });
            }

            var kalkulace = new KalkulaceGetModel { MzdoveNaklady = naklady.ToArray() };
            kalkulace.Recalculate();

            return Ok(kalkulace);
        }
    }

    internal class UserComparer : IEqualityComparer<UzivatelModel>
    {
        public bool Equals(UzivatelModel x, UzivatelModel y)
        {
            return x.Id == y.Id && x.Login == y.Login;
        }

        public int GetHashCode(UzivatelModel obj)
        {
            return obj.Id.GetHashCode() * obj.Login.GetHashCode();
        }
    }

}