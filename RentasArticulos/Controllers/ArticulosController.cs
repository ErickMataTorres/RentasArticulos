using Microsoft.AspNetCore.Mvc;

namespace RentasArticulos.Controllers
{
    public class ArticulosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
