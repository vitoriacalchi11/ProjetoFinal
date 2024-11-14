using Microsoft.AspNetCore.Mvc;

namespace ProjetoFloresta.Controllers
{
    public class PlanejamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
