using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoFloresta.Controllers
{
    public class HomeFController : Controller
    {
        [Authorize(Roles =" Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
