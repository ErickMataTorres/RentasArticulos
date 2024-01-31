using Microsoft.AspNetCore.Mvc;

namespace RentasArticulos.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
