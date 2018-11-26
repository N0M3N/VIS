using Databse;
using Models;
using Models.API_Models;
using System.Linq;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class StavebniDenikController : ApiController
    {
        private readonly StavebniDenikEntity DB_stavebniDenik;
        private readonly ZakazkaEntity DB_zakazka;
        private readonly UzivatelEntity DB_uzivatel;

        public StavebniDenikController()
        {
            DB_stavebniDenik = new StavebniDenikEntity();
            DB_zakazka = new ZakazkaEntity();
            DB_uzivatel = new UzivatelEntity();
        }

        [HttpGet]
        [Route("stavebniDenik/zakazka/{id}")]
        public IHttpActionResult ZaznamyZakazky([FromUri] int id)
        {
            var stavebniDenik = DB_stavebniDenik.Select().Where(x => x.Zakazka.Id == id);
            if (stavebniDenik != null) return Ok(stavebniDenik);

            return NotFound();
        }

        [HttpPut]
        [Route("stavebniDenik")]
        public IHttpActionResult Put([FromBody] StavebniDenikPostModel zaznam)
        {
            var model = DB_stavebniDenik.Insert(new StavebniDenikModel {
                Datum = zaznam.Datum,
                Popis = zaznam.Popis,
                Zakazka = DB_zakazka.Select(zaznam.ZakazkaId),
                Zamestnanec = DB_uzivatel.Select(zaznam.ZamestnanecId)
            });
            if (model != null) return Ok(model);

            return BadRequest();
        }
    }
}