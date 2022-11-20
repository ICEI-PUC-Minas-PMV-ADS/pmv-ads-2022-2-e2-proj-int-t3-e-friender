using Efriender.Data;
using Efriender.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Efriender.Controllers
{
    public class CombinacaoController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CombinacaoController(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;
        }

        public CombinacaoController(Combinacao combinacao)
        {
            this.Create(combinacao);
        }

        // GET: CombinacaoController


        public ActionResult Index()
        {
            return View();
        }

        // GET: CombinacaoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CombinacaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CombinacaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Combinacao combinacao)
        {
            try
            {   
                _context.Combinacoes.Add(combinacao);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return View();
            }
        }

        // GET: CombinacaoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CombinacaoController/Edit/5
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

        // GET: CombinacaoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CombinacaoController/Delete/5
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
