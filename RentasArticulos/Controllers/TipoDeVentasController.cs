using Microsoft.AspNetCore.Mvc;

namespace RentasArticulos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoDeVentasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("ConsultarTipoDeVentas")]
        public IActionResult ConsultarTipoDeVentas()
        {
            var r = Models.TipoDeVenta.ConsultarTipoDeVentas();
            return Json(r);
        }

        [HttpPost]
        [Route("EjecutarAccionTipoDeVenta")]
        public IActionResult EjecutarAccionTipoDeVenta([FromBody] Models.TipoDeVenta c)
        {
            var r = c.EjecutarAccionTipoDeVenta();
            return Json(r);
        }
        [HttpDelete]
        [Route("BorrarTipoDeVenta/{id}")]
        public IActionResult BorrarTipoDeVenta(int id)
        {
            var r = Models.TipoDeVenta.BorrarTipoDeVenta(id);
            return Json(r);
        }
    }
}
