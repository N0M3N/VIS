using Databse;
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

        [HttpGet]
        [Route("api/zakazka")]
        public IHttpActionResult Get()
        {
            var zakazky = DB_Zakazky.Select();
            if (zakazky.Any()) return Ok(zakazky);
            return NotFound();
        }

        [HttpGet]
        [Route("api/zakazka/{id}")]
        public IHttpActionResult Get(int id)
        {
            var zakazky = DB_Zakazky.Select(id);
            if (zakazky != null) return Ok(zakazky);
            return NotFound();
        }
    }
}