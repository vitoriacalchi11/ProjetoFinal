using Microsoft.AspNetCore.Mvc;

namespace ProjetoFloresta.Controllers
{
    public class SobreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
