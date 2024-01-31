using Microsoft.AspNetCore.Mvc;

namespace RentasArticulos.Controllers
{
    public class RentasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
