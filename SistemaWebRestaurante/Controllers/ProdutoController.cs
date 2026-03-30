using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using SistemaWebRestaurante.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaWebRestaurante.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: ProdutoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProdutoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProdutoController/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult List()
        {
            var lista = new List<Models.Produto>();
            var p1 = new Models.Produto();
            p1.Nome = "teste";
            p1.Quantidade = 1;
            p1.Descricao = "teste123";
            p1.Valor = 10.00m;

            lista.Add(p1);
            return View(lista);
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProdutoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProdutoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
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

        public IActionResult Details(int id)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
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
