using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Efriender.Data;
using Efriender.Models;


namespace Efriender.Controllers
{
    public class VisualizacaoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public bool result;

        #region [ CONSTRUTOR ]
        public VisualizacaoController(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;
        }


        public VisualizacaoController(ApplicationDbContext context, Visualizacao visualizacao)
        {
            this.Create(visualizacao);
        }

        //public VisualizacaoController()
        //{

        //}

        #endregion 

        #region [ GET ]

        // GET: VisualizacaoController
        public async Task<IActionResult> Curtido()
        {
            var Visualizacoes = _context.Visualizacoes;
            return Ok(Visualizacoes);

        }

        // -- Obter todas as visualizacoes por ID do Visualizador
        public List<Visualizacao> GetByVisualizador(string ID_Visualizador)
        {
            List<Visualizacao> lVisualizacao = new List<Visualizacao>();
            try
            {
                lVisualizacao = _context.Visualizacoes.Where(x => x.usuarioVisualizador.Id == ID_Visualizador).ToList();
                return lVisualizacao;
            } catch(Exception ex)
            {
                throw new Exception("erro ao obter lista de usuarios visualizados.", ex);
            }
        }

        public List<Visualizacao> GetByVisto(int ID_Visto)
        {
            List<Visualizacao> lVisualizacao = new List<Visualizacao>();
            return null;
        }
        /*

        var random = new Random();
        var usuario = await _context.Usuario
            .Include(u => u.Jogos)
            .FirstOrDefaultAsync(m => m.Id == 6); // alterar aqui
            if (usuario == null)
            {
                return NotFound();
    */

    // GET: VisualizacaoController/Details/5
    public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VisualizacaoController/Create
        public ActionResult Create()
        {
            return View();
        }


        // GET: VisualizacaoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        // GET: VisualizacaoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        #endregion

        #region [ POST ]
        // POST: VisualizacaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Visualizacao visualizacao)
        {

                _context.Add(visualizacao);
                await _context.SaveChangesAsync();
            return Ok();
 
        }

        // POST: VisualizacaoController/Edit/5
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

        // POST: VisualizacaoController/Delete/5
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

        #endregion


    }
}
