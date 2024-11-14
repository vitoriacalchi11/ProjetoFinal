using Microsoft.AspNetCore.Mvc;

namespace ProjetoFloresta.Controllers
{
    public class ControleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
