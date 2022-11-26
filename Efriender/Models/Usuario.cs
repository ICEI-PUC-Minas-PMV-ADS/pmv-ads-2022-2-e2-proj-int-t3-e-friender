using Efriender.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace EFriender.Models
{
    [Table("Usuário")]
    public class Usuario : IdentityUser

    {
        

        #region [ CONSTRUTORES ]

        public Usuario(string Id)
        {
            this.Id = Id;
        }

        public Usuario()
        {
        }

        public Usuario (Usuario usuario)
        {
            Id = usuario.Id;
            Imagem = usuario.Imagem;
            UrlImagem = usuario.UrlImagem;
            Nome = usuario.Nome;
            Idade = usuario.Idade;
            Genero = usuario.Genero;
            JogoSecundario = usuario.JogoSecundario;
            Discord = usuario.Discord;
            Curso = usuario.Curso;
            Faculdade = usuario.Faculdade;
            Descricao = usuario.Descricao;
            Preferencias = usuario.Preferencias;
            Jogo = usuario.Jogo;
        }

        #endregion



        //public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório inserir a Imagem de Perfil")]
        [Display(Name = "Imagem")]
        [NotMapped]
        public IFormFile? Imagem { get; set; }

        [Required(ErrorMessage = "Obrigatório inserir a Imagem de Perfil")]
        public string UrlImagem { get; set; } = "FotoPadrao.png";

        public string? Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório inserir a Idade")]
        public int Idade { get; set; }

        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "Obrigatório inserir o Gênero")]
        public Generos Genero { get; set; }
        public enum Generos
        {
            Masculino,
            Feminino,
        }

        [Display(Name = "Jogo Adicional")]
        public string? JogoSecundario { get; set; }

        public string? Discord { get; set; }

        [Required(ErrorMessage = "Obrigatório inserir o curso")]
        public string Curso { get; set; }

        [Required(ErrorMessage = "Obrigatório inserir a Faculdade")]
        public string Faculdade { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Obrigatório inserir a descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Preferências")]
        public string Preferencias { get; set; }

        [Display(Name = "Jogo Favorito")]
        [ForeignKey("Jogos")]
        [Required(ErrorMessage = "Obrigatório inserir o jogo")]
        public Jogo Jogo { get; set; }






        //[Key]
        //public int Id { get; set; }

        //private Task<Usuario?> loggedUser;
    }
}
