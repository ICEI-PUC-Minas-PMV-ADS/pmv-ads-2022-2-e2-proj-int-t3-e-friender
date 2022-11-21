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
using System.Security.Principal;
using Microsoft.Extensions.Caching.Memory;
using Efriender.Controllers;
using Efriender.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Configuration.Internal;

namespace EFriender.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private IMemoryCache cache;


        public UsuariosController(ApplicationDbContext context, IWebHostEnvironment webHost, IMemoryCache cache)
        {
            _context = context;
            webHostEnvironment = webHost;
            cache = cache;
        }

          // GET: Index
          [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext = _context.Usuario.Include(u => u.Jogos);
            return View(await ApplicationDbContext.ToListAsync());

        }


        public async Task<IActionResult> Home(int? id)
        {
            var ApplicationDbContext = _context.Usuario.Include(u => u.Jogos);
            return View(await ApplicationDbContext.ToListAsync());
        }




        [Authorize]
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

            /*List<int> ListaIds = new List<int>();
            var Usuario = _context.Usuario;

            foreach (var item in Usuario)
            {
                ListaIds.Add(item.Id);
            }

            ViewBag.Id = ListaIds;

            ViewBag.IdUltimo = ListaIds.Count() -1;

            ViewBag.IdInit = ListaIds[0];
            */
            return View(usuario);
        }

        public bool Passar(int ID_Visualizador, int ID_Visto)
        {
            try
            { 
                VisualizacaoController visualizacaoController = new VisualizacaoController(new Visualizacao(ID_Visualizador, ID_Visto));
                if (visualizacaoController.result) return true;
                else return false;
            } catch (Exception ex)
            {
                throw new Exception("Erro ao passar para outro gamer.", ex);
            }

        }

        public bool Match(int ID_Visualizador, int ID_Visto, bool like)
        {
            // -- adicionar lista de visualizacao que usuario visualizou
            VisualizacaoController visualizacaoController = new VisualizacaoController(new Visualizacao(ID_Visualizador, ID_Visto, like));
            
            // -- verificar na lista de visualizacao se usuario visualizado tambem curtiu
            List<Visualizacao> visualizadorVisto = new List<Visualizacao>();
        
            visualizadorVisto = visualizacaoController.GetByVisualizador(ID_Visto);
          
       
            var test = visualizadorVisto.Where(x => ID_Visualizador == x.Id_visualizador && x.like == true);

            // -- se sim, adiciona na tabela de Match o match dos dois usuarios, com flags de nao visualizado para os dois
            if (test.Any())
            {
                // adicionar na tabela de match
                CombinacaoController combinacaoController = new CombinacaoController(new Combinacao(ID_Visualizador, ID_Visto));

                // -- imprime um alerta na tela do usuario sobre o match
                //View("Swipe");
                //Ok();
                return true;
            }
            return false;



        }

        // -- botão swipe
        public async Task<IActionResult> btnSwipe()
        {
            // -- consulta a tabela de visualizacao, com todos usuarios visualizados pelo user
            var visualizacoes = new VisualizacaoController();
            // -- comsulta a lista de usuarios total, e excluir o proprio user dela

            // -- subtrai a lista de usuarios visualizados da lista total

            // -- gera a view
            return View(visualizacoes);
        }

        [Authorize]
        public async Task<IActionResult> Swipe2()
        {
            var random = new Random();

            string name = User.FindFirstValue(ClaimTypes.Email); // -- gambiarra


            // -- pega o id do usuario logado
                //string nameidentifier = User.FindFirstValue(ClaimTypes.NameIdentifier);
                //int userId = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                //var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                //var userId = int.TryParse(userIdClaim, out var id) ? id : 0;

            // -- cria uma instancia de um Usuario e associa o Id do usuario logado
            Usuario user = new Usuario(name);

            // -- cria uma lista de Usuarios
            List<Usuario> lUsuario = new List<Usuario>();

            // -- se user não for nulo, adiciona a lUsuario
            if (user != null) {
                lUsuario.Add(user);
            }

            // -- pegar todas as visualizações do usuario
            List<Visualizacao> visualizacoes = _context.Visualizacao.Include(v => v.Id_visualizador == 1).ToList();
            foreach(Visualizacao view in visualizacoes)
            {
                Usuario usuarioVisto = new Usuario(view.Id_visto);

                // -- adiciona o usuario visto a lista de usuarios criadas anteriormente
                lUsuario.Add(usuarioVisto);
            }

            // -- pega uma lista de usuarios no DB excluindo o usuario logado e os usuarios vistos
            List<Usuario> usuarios = _context.Usuario.ToList().Except(lUsuario).ToList();

            if(usuarios.Count <= 0)
            {
                // -- redirecionar para a pagina principal ou exibir uma mensagem de alerta informando sobre nao ter usuarios novos para visualizacao
                return NotFound();
            }

            // -- criando um numero randomico dentro do range da lista
            int lSize = usuarios.Count;
            Random r = new Random();
            int rInt = r.Next(0, lSize);

            return View(usuarios[rInt]);

        }


        [Authorize]
        public async Task<IActionResult> Swipe(int? id)
        {

            var random = new Random();
            var Usuario = _context.Usuario;
            List<int> ListaIds = new List<int>();

            foreach (var item in Usuario)
            {
                ListaIds.Add(item.Id);
            }

            var rand = ListaIds[random.Next(ListaIds.Count)];

            while (rand == id)
            {
                rand = ListaIds[random.Next(ListaIds.Count)];

            }



            ViewBag.Random = rand;

            ViewBag.Id = ListaIds;

            ViewBag.IdUltimo = ListaIds.Count() - 1;

            var usuario = await _context.Usuario
                .Include(u => u.Jogos)
                .FirstOrDefaultAsync(m => m.Id == id); // alterar aqui
            if (usuario == null)
            {
                return NotFound();
            }

            //var idCount = _context.Usuario;
            //ViewBag.Id = idCount.Count();

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

            _context.Attach(usuarios);
            _context.Entry(usuarios).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction(nameof(Home));

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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Idade,Genero,Nick,Discord,Curso,Faculdade,Descricao,Preferencias,JogosId,Imagem")] Usuario usuario)
        {
            usuario.Nome = User.Identity.Name;
            if (id != usuario.Id)
            {
                return NotFound();
            }


                try
                {
                string uniqueFileName = Imagem(usuario);

                usuario.UrlImagem = uniqueFileName;

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

            ViewData["JogosId"] = new SelectList(_context.Jogos, "Id", "Id", usuario.JogosId);
            return View(usuario);
        }

        [Authorize]
 
        public async Task<IActionResult> Perfil(int? id)
        {

            ViewData["JogosId"] = new SelectList(_context.Jogos, "Id", "Nome");

            var usuarioId = _context.Usuario;

            

            foreach (var item in usuarioId)
            {
                if(item.Nome == User.Identity.Name)
                {
                    id = item.Id;
                }
            }

            ViewBag.Id = id;

            if (id == null || _context.Usuario == null)
            {
                return View("Create");
            }

            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            if (usuario.Nome == User.Identity.Name)
            {
                ViewData["JogosId"] = new SelectList(_context.Jogos, "Id", "Nome", usuario.JogosId);
                return View(usuario);
            }

            return Unauthorized();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Perfil(int id, [Bind("Id,Idade,Genero,Nick,Discord,Curso,Faculdade,Descricao,Preferencias,JogosId,Imagem")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

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
            return RedirectToAction(nameof(Home));

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
            return RedirectToAction(nameof(Home));
        }

        private bool UsuarioExists(int id)
        {
          return _context.Usuario.Any(e => e.Id == id);
        }
    }
}
