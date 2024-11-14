using Microsoft.AspNetCore.Mvc;

namespace ProjetoFloresta.Controllers
{
    public class CampanhaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
