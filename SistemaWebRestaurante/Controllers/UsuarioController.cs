using Microsoft.AspNetCore.Mvc;

namespace SistemaWebRestaurante.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string email, string senha)
        {
            if (email == "admin@restaurante.com" && senha == "123")
            {
                HttpContext.Session.SetString("usuario", "admin");

                return RedirectToAction("Index", "Produto");
            }
            else
            {
                HttpContext.Session.SetString("usuario", email);
                return RedirectToAction("Index", "Produto");
            }

            ViewBag.Erro = "Login inválido";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
