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
using SQLitePCL;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
using Efriender.Controllers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MySqlX.XDevAPI;
using System.Composition;

namespace EFriender.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;


        public UsuariosController(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            this.webHostEnvironment = webHost;
        }

          // GET: Index
          [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext = _context.Usuarios.Include(u => u.Jogo);
            return View(await ApplicationDbContext.ToListAsync());

        }


        public async Task<IActionResult> Home(int? id)
        {
            var ApplicationDbContext = _context.Usuarios; 
            return View(await ApplicationDbContext.ToListAsync());
        }

        #region [ MÉTODOS ] 

        public async Task<IActionResult> Swipe()
        {
            var random = new Random();

            // -- id do usuario logado na sessão
            string sessionId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // -- cria uma lista de Usuarios
            List<Usuario> lUsuario = new List<Usuario>();

            // -- recupera o usuario logado e adiciona na lista
            Usuario usuarioLogado = _context.Usuarios.Where(u => u.Id == sessionId).FirstOrDefault();
            lUsuario.Add(usuarioLogado);

            List<Visualizacao> visualizacoesTest = _context.Visualizacoes.Include(x => x.usuarioVisto).ToList();

            // -- pegar todas as visualizações do usuario
            List<Visualizacao> visualizacoes = _context.Visualizacoes.Where(v => v.usuarioVisualizador.Id == usuarioLogado.Id).Include(x => x.usuarioVisto).ToList();
            foreach (Visualizacao view in visualizacoes)
            {
                // -- adiciona o usuario visto a lista de usuarios criadas anteriormente
                lUsuario.Add(view.usuarioVisto);
            }

            // -- lista de usuarios ainda não vistos
            List<Usuario> usuariosNaoVistos = _context.Usuarios.Include(x => x.Jogo).ToList().Except(lUsuario).ToList();

            // -- se não houverem usuarios para serem visualizados
            if (usuariosNaoVistos.Count <= 0)
            {
                //List<Visualizacao> visualizacoes = _context.Visualizacoes.Where(v => v.Id == usuarioLogado.Id).ToList();
                usuariosNaoVistos = _context.Usuarios.Include(x => x.Jogo).ToList();
                foreach(Visualizacao view in visualizacoes)
                {
                    _context.Visualizacoes.Remove(view);
                }
               
                _context.SaveChangesAsync();
                usuariosNaoVistos.Remove(usuarioLogado);
                
                // -- redirecionar para a pagina principal ou exibir uma mensagem de alerta informando sobre nao ter usuarios novos para visualizacao
                ////return NotFound();
                //return RedirectToAction(nameof(Home));
            }

            // -- criando um numero randomico dentro do range da lista
            int lSize = usuariosNaoVistos.Count;
            Random r = new Random();
            int rInt = r.Next(0, lSize);
            return View(usuariosNaoVistos[rInt]);

        }


        public async Task<IActionResult> Passar(string usuarioVistoID)
        {
            try
            {
                // -- pegar o id do usuario da sessao
                string sessionId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                Usuario usuarioVisualizador = _context.Usuarios.Where(u => u.Id == sessionId).FirstOrDefault();
                Usuario usuarioVisto = _context.Usuarios.Where(u => u.Id == usuarioVistoID).FirstOrDefault();
            
                Visualizacao visualizacao = new Visualizacao(usuarioVisualizador, usuarioVisto);

                _context.Visualizacoes.Add(visualizacao);
                _context.SaveChanges();
                
                return RedirectToAction(nameof(Swipe));

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao passar para outro gamer.", ex);
            }

        }

        public async Task<IActionResult> Match(string usuarioVistoID)
        {

            // -- salvar a visualizacao na tabela de visualizacao
            try
            {
                Visualizacao visualizacao = new Visualizacao(this.getUsuarioVisualizador(), this.getUsuarioVisto(usuarioVistoID), true);
                _context.Visualizacoes.Add(visualizacao);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao salvar visualizacão.", ex);
            }

            // -- verificar na lista de visualizacao se usuario visualizado tambem curtiu
            Visualizacao visualizacaoOposta = _context.Visualizacoes.Where(x => x.usuarioVisualizador.Id == usuarioVistoID).Where(x => x.usuarioVisto.Id == this.getUsuarioVisualizador().Id).FirstOrDefault();

            // -- se os dois usuarios tiverem se curtido, é match!
            if (visualizacaoOposta != null && visualizacaoOposta.like)
            {
                // -- salvar o match na tabela de combinação
                try
                {
                    Combinacao combinacao = new Combinacao(this.getUsuarioVisualizador(), this.getUsuarioVisto(usuarioVistoID));
                    _context.Combinacoes.Add(combinacao);
                    _context.SaveChanges();
                } catch (Exception ex)
                {
                    throw new Exception("Erro ao salvar novo match.", ex);
                }
                // -- imprimir mensagem de alerta na tela
            }

            return RedirectToAction(nameof(Swipe));

        

        }

        #endregion

        #region [ UTILS ]

        public Usuario getUsuarioVisto(string usuarioVistoID)
        {
            try
            {
                Usuario usuarioVisto = _context.Usuarios.Where(u => u.Id == usuarioVistoID).FirstOrDefault();
                return usuarioVisto;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter usuario visto por ID.", ex);
            }
        }

      
        public Usuario getUsuarioVisualizador()
        {
                try
                {
                    string sessionId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Usuario usuarioVisualizador = _context.Usuarios.Where(u => u.Id == sessionId).FirstOrDefault();
                    return usuarioVisualizador;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao obter usuario visualizador por ID.", ex);
                }
        }

        #endregion

        [Authorize]
        // GET: DetailsID
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null || _context.Usuarios == null)
            {

                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.Jogo)
                .FirstOrDefaultAsync(m => m.Id == id); // alterar aqui
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

        // GET: Usuarios
        public async Task<IActionResult> Usuarios()
        {
            var ApplicationDbContext = _context.Usuarios.Include(u => u.Jogo);
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
        public IActionResult Create(Usuario usuario)
        {
            string uniqueFileName = Imagem(usuario);

            usuario.UrlImagem = uniqueFileName;

            usuario.Nome = User.Identity.Name;

            _context.Attach(usuario);
            _context.Entry(usuario).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction(nameof(Home));

        }

        private string Imagem(Usuario usuario)
        {
            string uniqueFileName = null;

            if (usuario.Imagem != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "imagens");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + usuario.Imagem.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    usuario.Imagem.CopyTo(filestream);
                }
            }
            return uniqueFileName;
        }

        // GET: Usuarios/Edit/5



        //POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id, Nome,Idade,Genero,Discord,Descricao,Jogo,Imagem,Preferencias,Curso,Faculdade")] Usuario usuario)
        {
            //Usuario usuarioSessao = _context.Usuarios.Where(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
            if (usuario == null || usuario.Id != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return NotFound();
            }

            Usuario userToUpdate = _context.Usuarios.Where(u => u.Id == usuario.Id).FirstOrDefault();
            if (userToUpdate != null)
            {
                try
                {
                    // -- atualizando atributos
                    string uniqueFileName = Imagem(usuario);
                    if(!string.IsNullOrEmpty(uniqueFileName)) userToUpdate.UrlImagem = uniqueFileName;
                    userToUpdate.Discord = usuario.Discord;
                    userToUpdate.Curso = usuario.Curso;
                    userToUpdate.Faculdade = usuario.Faculdade;
                    userToUpdate.Preferencias = usuario.Preferencias;
                    userToUpdate.Genero = usuario.Genero;
                    userToUpdate.Idade = usuario.Idade;
                    if (!string.IsNullOrEmpty(usuario.Nome))
                    {
                        userToUpdate.Nome = usuario.Nome;
                    }

                    userToUpdate.Jogo = _context.Jogos.Where(v => v.JogosId == usuario.Jogo.JogosId).FirstOrDefault();
                    if (string.IsNullOrEmpty(usuario.Descricao))
                    {
                        userToUpdate.Descricao = " ";
                    } else
                    {
                        userToUpdate.Descricao = usuario.Descricao;
                    }
                    

                    // -- atualizando e salvando no db
                    _context.Usuarios.Update(userToUpdate);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Home));

                } catch (Exception ex)
                {
                    throw new Exception("Erro ao editar perfil do usuario.", ex);
                }
            }
            return RedirectToAction("Error", "Shared");
        }
                //public async Task<IActionResult> Perfil(int? id)
                //{

                //    ViewData["JogosId"] = new SelectList(_context.Jogos, "Id", "Nome");

                //    var usuarioId = _context.Usuario;



                //    foreach (var item in usuarioId)
                //    {
                //        if(item.Nome == User.Identity.Name)
                //        {
                //            id = item.Id;
                //        }
                //    }
                //        userUpdate.UrlImagem = uniqueFileName;

                //        _context.Update(userUpdate);
                //        await _context.SaveChangesAsync();
                //        }
                //        catch (DbUpdateConcurrencyException)
                //        {
                //            if (!UsuarioExists(userUpdate.Id))
                //            {
                //                return NotFound();
                //            }
                //            else
                //            {
                //                throw;
                //            }
                //        }
                //        return RedirectToAction(nameof(Home));

                //    ViewData["JogosId"] = new SelectList(_context.Jogos, "Id", "Nome", userUpdate.Jogo.JogosId);
                //    return View(usuario);
                //}

                [Authorize]
 
        public async Task<IActionResult> Perfil(string id)
        {

            ViewData["JogosId"] = new SelectList(_context.Jogos, "Id", "Nome");

            var usuarioId = _context.Usuarios.ToList();

            

            foreach (var item in usuarioId)
            {
                if(item.Nome == User.Identity.Name)
                {
                    id = item.Id;
                }
            }

        
            Usuario usuarioSessao = _context.Usuarios.Where(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Include(v => v.Jogo).FirstOrDefault();

            //if (id == null || _context.Usuarios == null)
            //{
            //    return View("Create");
            //}

            if (usuarioSessao == null)
            {
                return NotFound();
            }
            var urlimg = usuarioSessao.UrlImagem;
            //var check = new SelectList(_context.Jogos, "JogosId", "Nome");
            ViewData["JogosId"] = new SelectList(_context.Jogos, "JogosId", "Nome");
            return View(usuarioSessao);
            //return View(usuarioSessao);
          

            return Unauthorized();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Perfil(string id, [Bind("Id,Idade,Genero,Nick,Discord,Curso,Faculdade,Descricao,Preferencias,JogosId,Imagem")] Usuario usuario)
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

            ViewData["JogosId"] = new SelectList(_context.Jogos, "Id", "Id", usuario.Jogo.JogosId);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.Jogo.JogosId)
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
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Usuario'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Home));
        }

        private bool UsuarioExists(string id)
        {
            
          return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
