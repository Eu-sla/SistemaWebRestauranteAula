using Microsoft.AspNetCore.Mvc;
using SistemaWebRestaurante.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaWebRestaurante.Controllers
{
    public class ProdutoController : Controller
    {
        private static readonly List<Produto> _produtos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "Pizza", Quantidade = 10, Descricao = "Pizza grande", Valor = 35.00m },
            new Produto { Id = 2, Nome = "Refrigerante", Quantidade = 50, Descricao = "Refrigerante 2L", Valor = 8.50m }
        };

        public IActionResult Index()
        {
            var usuario = HttpContext.Session.GetString("usuario");
            ViewBag.Usuario = usuario;
            ViewBag.EhAdmin = usuario == "admin";
            return View(_produtos);
        }

        public IActionResult Create()
        {
            var usuario = HttpContext.Session.GetString("usuario");
            if (usuario != "admin")
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produto produto)
        {
            var usuario = HttpContext.Session.GetString("usuario");
            if (usuario != "admin")
            {
                return RedirectToAction("Index");
            }

            if (produto == null)
            {
                return RedirectToAction("Index");
            }

            var novoId = _produtos.Any() ? _produtos.Max(p => p.Id) + 1 : 1;
            produto.Id = novoId;
            _produtos.Add(produto);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var usuario = HttpContext.Session.GetString("usuario");
            if (usuario != "admin")
            {
                return RedirectToAction("Index");
            }

            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            if (produto != null)
            {
                _produtos.Remove(produto);
            }

            return RedirectToAction("Index");
        }
    }
}