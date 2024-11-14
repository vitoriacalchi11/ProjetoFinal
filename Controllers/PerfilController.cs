using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ProjetoFloresta.Controllers
{
    public class PerfilController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
       
        private readonly UserManager<IdentityUser> _userManager;

        public PerfilController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _userManager.FindByIdAsync(userId);
                ViewData["UserName"] = User.Identity.Name;
                //ViewData["Nome"] = User.FindFirst(ClaimTypes.Nome)?.Value;
                //ViewData["Telefone"] = User.FindFirst(ClaimTypes.Telefone)?.Value;
                ViewData["Email"] = User.FindFirst(ClaimTypes.Email)?.Value;
                return View();
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage("/Account/Login", new { area = "Identity" });

        }

        

    }
}
