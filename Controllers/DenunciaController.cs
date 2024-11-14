using Microsoft.AspNetCore.Mvc;
using ProjetoFloresta.Data;
using ProjetoFloresta.Models;

namespace ProjetoFloresta.Controllers
{
    public class DenunciaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DenunciaController()
        {
            _context = new ApplicationDbContext(); // Instância do contexto do Entity Framework
        }

        // GET: Formulario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Formulario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DenunciaModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Adiciona o objeto model ao contexto do banco de dados
                    _context.DenunciaModel.Add(model);
                    _context.SaveChanges(); // Salva as alterações no banco de dados

                    TempData["SuccessMessage"] = "Dados salvos com sucesso!";
                    return RedirectToAction("Index"); // Redireciona para uma página, como a lista de registros
                }
                catch (Exception ex)
                {
                    // Log do erro para fins de depuração
                    Console.WriteLine("Erro ao salvar os dados: " + ex.Message);
                    ModelState.AddModelError("", "Erro ao salvar os dados. Tente novamente.");
                }
            }
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
}
