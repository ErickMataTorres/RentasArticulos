using Microsoft.AspNetCore.Mvc;

namespace RentasArticulos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("ConsultarRoles")]
        public IActionResult ConsultarRoles()
        {
            var r = Models.Rol.ConsultarRoles();
            return Json(r);
        }
        [HttpPost]
        [Route("EjecutarAccionRol")]
        public IActionResult EjecutarAccionRol([FromBody] Models.Rol c)
        {
            var r = c.EjecutarAccionRol();
            return Json(r);
        }

    }
}
