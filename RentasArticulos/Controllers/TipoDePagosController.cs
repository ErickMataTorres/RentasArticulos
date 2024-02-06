using Microsoft.AspNetCore.Mvc;

namespace RentasArticulos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoDePagosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("ConsultarTipoDePagos")]
        public IActionResult ConsultarTipoDePagos()
        {
            var r = Models.TipoDePago.ConsultarTipoDePagos();
            return Json(r);
        }

        [HttpPost]
        [Route("EjecutarAccionTipoDePago")]
        public IActionResult EjecutarAccionTipoDePago([FromBody] Models.TipoDePago c)
        {
            var r = c.EjecutarAccionTipoDePago();
            return Json(r);
        }
        [HttpDelete]
        [Route("BorrarTipoDePago/{id}")]
        public IActionResult BorrarTipoDePago(int id)
        {
            var r = Models.TipoDePago.BorrarTipoDePago(id);
            return Json(r);
        }

    }
}
