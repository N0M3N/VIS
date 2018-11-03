using Databse;
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
        [Route("api/StavebniDenik/{id}")]
        public IHttpActionResult Get(int id)
        {
            var stavebniDenik = DB_stavebniDentik.Select(id);
            if (stavebniDenik != null) return Ok(stavebniDenik);
            return NotFound();
        }
    }
}