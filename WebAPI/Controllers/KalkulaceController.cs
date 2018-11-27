using Databse;
using Models.API_Models;
using System.Linq;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class KalkulaceController : ApiController
    {
        private readonly MzdaEntity mzdaEntity;
        private readonly DochazkaEntity dochazkaEntity;
        private readonly ZakazkaEntity zakazkaEntity;

        public KalkulaceController()
        {
            mzdaEntity = new MzdaEntity();
            dochazkaEntity = new DochazkaEntity();
            zakazkaEntity = new ZakazkaEntity();
        }

        [HttpGet]
        [Route("kalkulace/{id}")]
        public IHttpActionResult GetProZakazku([FromUri] int id)
        {
            var zakazka = zakazkaEntity.Select(id);
            if (zakazka == null) return NotFound();

            var mzdy = mzdaEntity.Select().Where(x => x.Zakazka == zakazka);
            var dochazka = dochazkaEntity.Select().Where(x => x.Zakazka == zakazka);

            var kalkulace = new KalkulaceGetModel(zakazka, dochazka, mzdy);

            return Ok(kalkulace);
        }
    }
}