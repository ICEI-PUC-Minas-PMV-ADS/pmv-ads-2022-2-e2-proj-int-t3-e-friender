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

        #region [ PROPRIEDADES ]

        [Required(ErrorMessage = "Obrigatório inserir nome")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório inserir a Idade")]
        public int Idade { get; set; }

        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "Obrigatório inserir o Gênero")]
        public Generos Genero { get; set; }

        [Required(ErrorMessage = "Obrigatório inserir a Faculdade")]
        public string Faculdade { get; set; }

        [Required(ErrorMessage = "Obrigatório inserir o curso")]
        public string Curso { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Obrigatório inserir a descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Preferências")]
        public string? Preferencias { get; set; }
        public string? Discord { get; set; }

        [Display(Name = "Jogo Adicional")]
        public string? JogoSecundario { get; set; }

        [Display(Name = "Jogo Favorito")]
        [ForeignKey("Jogos")]
        [Required(ErrorMessage = "Obrigatório inserir o jogo")]
        public int JogosId { get; set; }
        public Jogos Jogos { get; set; }

        [Required(ErrorMessage = "Obrigatório inserir a Imagem de Perfil")]
        [Display(Name = "Imagem")]
        [NotMapped]
        public IFormFile? Imagem { get; set; }

        [Required(ErrorMessage = "Obrigatório inserir a Imagem de Perfil")]
        public string UrlImagem { get; set; } = "FotoPadrao.png";

        #endregion

        #region [ ENUMS ]
        public enum Generos
        {
            Masculino,
            Feminino,
        }

        #endregion


    }
}
