using Efriender.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace EFriender.Models
{
    [Table("Usuário")]
    public class Usuario

    {
        private Task<Usuario?> loggedUser;

        #region [ CONSTRUTORES ]

        public Usuario(int Id)
        {
            this.Id = Id;
        }

        public Usuario(string username)
        {
            this.Nome = username;
        }

        public Usuario(Task<Usuario?> loggedUser)
        {
            this.Id = loggedUser.Id;
        }

        #endregion

        [Key]
        public int Id { get; set; }

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
        public int JogosId { get; set; }

        public Jogos Jogos { get; set; }

        public ICollection<Visualizacao>? VisualizacoesRealizadas { get; set; }
        public ICollection<Visualizacao>? VisualizacoesRecebidas { get; set; }

        public ICollection<Combinacao>? UsuarioPrimario { get; set; }
        public ICollection<Combinacao>? UsuarioSecundario { get; set; }


    }
}
