using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFriender.Models;
using Efriender.Data;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics.Metrics;
using Newtonsoft.Json.Linq;
using NuGet.Packaging.Signing;
using Efriender.Areas.Identity;
using System.Linq;
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


        public VisualizacaoController(Visualizacao visualizacao)
        {
            this.result = this.Create(visualizacao);
        }

        public VisualizacaoController()
        {

        }

        #endregion 

        #region [ GET ]

        // GET: VisualizacaoController
        public async Task<IActionResult> Curtido()
        {
            var Visualizacoes = _context.Visualizacao;
            return Ok(Visualizacoes);

        }

        // -- Obter todas as visualizacoes por ID do Visualizador
        public List<Visualizacao> GetByVisualizador(int ID_Visualizador)
        {
            List<Visualizacao> lVisualizacao = new List<Visualizacao>();
            try
            {
                lVisualizacao = _context.Visualizacao.Where(x => x.usuarioVisualizador.Id == ID_Visualizador).ToList();
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
        public bool Create(Visualizacao visualizacao)
        {
            try
            {
                _context.Visualizacao.Add(visualizacao);
                _context.SaveChanges();
                return true;
                //return RedirectToAction(nameof(Index)); //ActionREsult
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir nova visualização.", ex);
            }
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
