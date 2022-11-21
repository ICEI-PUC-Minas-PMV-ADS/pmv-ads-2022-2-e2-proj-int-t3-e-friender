using EFriender.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Efriender.Models
{
    public class ApplicationUser : IdentityUser
    {

        #region [ CONSTRUTORES ]

        public ApplicationUser(string id)
        {
            this.Id = id;
        }

        #endregion

        [Key]
        //public new int Id { get; set; }

        public string Email { get; set; }

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
        public string? Preferencias { get; set; }

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
