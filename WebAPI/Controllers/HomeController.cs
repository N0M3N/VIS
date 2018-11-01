using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var asm = Assembly.GetExecutingAssembly();

            var controllers = asm.GetTypes()
                .Where(type => typeof(ApiController).IsAssignableFrom(type)); //filter controllers
            var methods = controllers.Select(
                controller => new ControllerModel
                {
                    Name = controller.Name.Replace("Controller", ""),
                    Methods = controller.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                        .Select(method => new MethodModel
                        {
                            Name = method.Name,
                            Params = method.GetParameters().Select(parameter => parameter.Name).ToArray()
                        }).ToArray()
                });


            ViewBag.controllers = methods;

            return View();
        }
    }

    public class ControllerModel
    {
        public string Name;
        public MethodModel[] Methods;
    }

    public class MethodModel
    {
        public string Name;
        public string[] Params;
    }
}
