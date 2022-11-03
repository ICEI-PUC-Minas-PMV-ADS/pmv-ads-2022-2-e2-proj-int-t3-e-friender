using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFriender.Models;
using Efriender.Data;
using Microsoft.AspNetCore;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;
using Efriender.Areas.Identity;

namespace EFriender.Controllers
{
    public class JogosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public JogosController(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;
        }

        // GET: Index
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Index()
        {
              return View(await _context.Jogos.ToListAsync());
        }

        // GET: Jogos
        public async Task<IActionResult> Jogos()
        {
            return View(await _context.Jogos.ToListAsync());
        }

        // GET: Jogos/Ver Mais/5
        public async Task<IActionResult> VerMais(int? id)
        {
            if (id == null || _context.Jogos == null)
            {
                return NotFound();
            }

            var jogos = await _context.Jogos
                .Include(t => t.Usuarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogos == null)
            {
                return NotFound();
            }

            return View(jogos);
        }

        // GET: Jogos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jogos == null)
            {
                return NotFound();
            }

            var jogos = await _context.Jogos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogos == null)
            {
                return NotFound();
            }

            return View(jogos);
        }

        private string Imagem(Jogos jogos)
        {
            string uniqueFileName = null;

            if(jogos.Imagem != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "imagens");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + jogos.Imagem.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    jogos.Imagem.CopyTo(filestream);
                }
            }
            return uniqueFileName;
        }

        // GET: Jogos/Create
        public IActionResult Create()
        {
            //Jogos jogos = new Jogos();
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        /*public async Task<IActionResult> Create([Bind("Id,Nome,Imagem,Descricao")] Jogos jogos)
        {
            _context.Add(jogos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            return View(jogos);
        }*/


        public IActionResult Create(Jogos jogos)
        {
            string uniqueFileName = Imagem(jogos);
            
            jogos.UrlImagem = uniqueFileName;
            
            _context.Attach(jogos);
            _context.Entry(jogos).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        // GET: Jogos/Edit/5
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jogos == null)
            {
                return NotFound();
            }

            var jogos = await _context.Jogos.FindAsync(id);
            if (jogos == null)
            {
                return NotFound();
            }
            return View(jogos);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Imagem,UrlImagem,Descricao")] Jogos jogos)
        {

            if (id != jogos.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(jogos);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JogosExists(jogos.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));



            return View(jogos);
        }



        

        // GET: Jogos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jogos == null)
            {
                return NotFound();
            }

            var jogos = await _context.Jogos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogos == null)
            {
                return NotFound();
            }

            return View(jogos);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jogos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Jogos'  is null.");
            }
            var jogos = await _context.Jogos.FindAsync(id);
            if (jogos != null)
            {
                _context.Jogos.Remove(jogos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogosExists(int id)
        {
          return _context.Jogos.Any(e => e.Id == id);
        }
    }
}
