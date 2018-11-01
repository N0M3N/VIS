using Databse;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ZakazkaController : ApiController
    {
        [HttpGet]
        [Route("api/zakazka")]
        public IHttpActionResult Get()
        {
            return Ok(new ZakazkaEntity().Select());
        }
    }
}