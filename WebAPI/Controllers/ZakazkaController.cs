using Databse;
using Models;
using System.Linq;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ZakazkaController : ApiController
    {
        private readonly ZakazkaEntity DB_Zakazky;
        public ZakazkaController()
        {
            DB_Zakazky = new ZakazkaEntity();
        }

        [HttpPost]
        [Route("zakazka")]
        public IHttpActionResult GetByUser([FromBody] UzivatelModel uzivatel)
        {
            var zakazky = DB_Zakazky
                .Select()
                .Where(x => x.ZodpovednyZamestnanec.Id == uzivatel.Id || x.Zakaznik.Id == uzivatel.Id);

            if (zakazky.Any())
                return Ok(zakazky);
            return NotFound();
        }

        [HttpGet]
        [Route("zakazka/{id}")]
        public IHttpActionResult Get([FromUri] int id)
        {
            var zakazka = DB_Zakazky.Select(id);

            if (zakazka != null)
                return Ok(zakazka);
            return NotFound();
        }
    }
}