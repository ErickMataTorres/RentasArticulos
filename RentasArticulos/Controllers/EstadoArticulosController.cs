using Microsoft.AspNetCore.Mvc;

namespace RentasArticulos.Controllers
{
    public class EstadoArticulosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
