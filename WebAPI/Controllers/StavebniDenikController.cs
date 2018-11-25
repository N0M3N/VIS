using Databse;
using Models;
using System.Linq;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class StavebniDenikController : ApiController
    {
        private readonly StavebniDenikEntity DB_stavebniDentik;

        public StavebniDenikController()
        {
            DB_stavebniDentik = new StavebniDenikEntity();
        }

        [HttpGet]
        [Route("stavebniDenik")]
        public IHttpActionResult Get(ZakazkaModel zakazka)
        {
            var stavebniDenik = DB_stavebniDentik.Select().Where(x => x.Zakazka.Id == zakazka.Id);
            if (stavebniDenik != null) return Ok(stavebniDenik);
            return NotFound();
        }
    }
}