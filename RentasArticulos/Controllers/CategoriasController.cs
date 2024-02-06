using Microsoft.AspNetCore.Mvc;

namespace RentasArticulos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("ConsultarCategorias")]
        public IActionResult ConsultarCategorias()
        {
            var r = Models.Categoria.ConsultarCategorias();
            return Json(r);
        }

        [HttpPost]
        [Route("EjecutarAccionCategoria")]
        public IActionResult EjecutarAccionCategoria([FromBody] Models.Categoria c)
        {
            var r = c.EjecutarAccionCategoria();
            return Json(r);
        }
        [HttpDelete]
        [Route("BorrarCategoria/{id}")]
        public IActionResult BorrarCategoria(int id)
        {
            var r = Models.Categoria.BorrarCategoria(id);
            return Json(r);
        }
    }
}
