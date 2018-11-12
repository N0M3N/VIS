using Databse;
using System.Linq;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class UzivatelController : ApiController
    {
        private readonly UzivatelEntity DB_Uzivatel;

        public UzivatelController()
        {
            this.DB_Uzivatel = new UzivatelEntity();
        }

        [HttpPost]
        [Route("api/login/{login}")]
        public IHttpActionResult Login([FromUri] string login, [FromBody] string password)
        {
            var user = DB_Uzivatel.Login(login, password);
            if (user != null)
                return Ok(user);
            else return Unauthorized();
        }
    }
}