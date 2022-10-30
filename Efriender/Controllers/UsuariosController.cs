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

namespace EFriender.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;


        public UsuariosController(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;
        }

        // GET: Index
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext = _context.Usuario.Include(u => u.Jogos);
            return View(await ApplicationDbContext.ToListAsync());

        }

        public async Task<IActionResult> Perfil()
        {
            var ApplicationDbContext = _context.Usuario.Include(u => u.Jogos);
            return View(await ApplicationDbContext.ToListAsync());

        }


        // GET: DetailsID
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.Jogos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            //var idCount = _context.Usuario;
            //ViewBag.Id = idCount.Count();

            List<int> ListaIds = new List<int>();

            var Usuario = _context.Usuario;


            foreach (var item in Usuario)
            {
                ListaIds.Add(item.Id);
            }

            ViewBag.Id = ListaIds;

            ViewBag.IdUltimo = ListaIds.Count() -1;

            return View(usuario);
        }

        // GET: Usuarios
        public async Task<IActionResult> Usuarios()
        {
            var ApplicationDbContext = _context.Usuario.Include(u => u.Jogos);
            return View(await ApplicationDbContext.ToListAsync());
        }


        // GET: Usuarios/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["JogosId"] = new SelectList(_context.Jogos, "Id", "Nome");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuario usuarios)
        {
            string uniqueFileName = Imagem(usuarios);

            usuarios.UrlImagem = uniqueFileName;

            usuarios.Nome = User.Identity.Name;

            if(usuarios.JogoSecond == 0)
            {
                usuarios.JogoSecond = null;
            }

            _context.Attach(usuarios);
            _context.Entry(usuarios).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction(nameof(Usuarios));

        }

        private string Imagem(Usuario usuarios)
        {
            string uniqueFileName = null;

            if (usuarios.Imagem != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "imagens");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + usuarios.Imagem.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    usuarios.Imagem.CopyTo(filestream);
                }
            }
            return uniqueFileName;
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            if (usuario.Nome == User.Identity.Name)
            {
                ViewData["JogosId"] = new SelectList(_context.Jogos, "Id", "Id", usuario.JogosId);
                return View(usuario);
            }

            return Unauthorized();

        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Idade,Genero,Nick,Discord,Curso,Faculdade,Descricao,Preferencias,JogosId")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["JogosId"] = new SelectList(_context.Jogos, "Id", "Id", usuario.JogosId);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.Jogos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuario == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Usuario'  is null.");
            }
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
            }


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return _context.Usuario.Any(e => e.Id == id);
        }
    }
}
