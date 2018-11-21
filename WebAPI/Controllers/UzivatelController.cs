using Databse;
using Models;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class UzivatelController : ApiController
    {
        private readonly UzivatelEntity DB_Uzivatel;

        public UzivatelController()
        {
            DB_Uzivatel = new UzivatelEntity();
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] LoginModel creds)
        {
            var user = DB_Uzivatel.Login(creds.Login, creds.Password);
            if (user != null)
                return Ok(user);
            else return Unauthorized();
        }
    }
}