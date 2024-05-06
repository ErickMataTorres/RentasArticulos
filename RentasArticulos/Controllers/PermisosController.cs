using Microsoft.AspNetCore.Mvc;

namespace RentasArticulos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermisosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("ConsultarPermisosPorIdRol")]
        public IActionResult ConsultarPermisosPorIdRol(int idRol)
        {
            var r = Models.Permiso.ConsultarPermisosPorIdRol(idRol);
            return Json(r);
        }
        [HttpPost]
        [Route("GuardarPermisos")]
        public IActionResult GuardarPermisos([FromBody] Models.Permiso c)
        {
            var r = c.GuardarPermisos();
            return Json(r);
        }
    }
}
