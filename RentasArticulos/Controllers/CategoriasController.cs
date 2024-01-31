using Microsoft.AspNetCore.Mvc;

namespace RentasArticulos.Controllers
{
    public class CategoriasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
