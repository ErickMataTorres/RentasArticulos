using Microsoft.AspNetCore.Mvc;

namespace RentasArticulos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstadoArticulosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("ConsultarEstadoArticulos")]
        public IActionResult ConsultarEstadoArticulos()
        {
            var r = Models.EstadoArticulo.ConsultarEstadoArticulos();
            return Json(r);
        }

        [HttpPost]
        [Route("EjecutarAccionEstadoArticulo")]
        public IActionResult EjecutarAccionEstadoArticulo([FromBody] Models.EstadoArticulo c)
        {
            var r = c.EjecutarAccionEstadoArticulo();
            return Json(r);
        }
        [HttpDelete]
        [Route("BorrarEstadoArticulo/{id}")]
        public IActionResult BorrarEstadoArticulo(int id)
        {
            var r = Models.EstadoArticulo.BorrarEstadoArticulo(id);
            return Json(r);
        }
    }
}
