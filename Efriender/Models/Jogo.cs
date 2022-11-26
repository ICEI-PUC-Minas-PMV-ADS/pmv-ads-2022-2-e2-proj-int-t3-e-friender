using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using Microsoft.AspNetCore.Http;
using Efriender.Models;

namespace EFriender.Models
{
    [Table("Jogos")]
    public class Jogo
    {
        
        [Key]
        public int JogosId { get; set; } // mudar para Id

        [Required(ErrorMessage = "Obrigatório inserir a Imagem do Jogo")]
        [Display(Name ="Imagem do jogo")]
        [NotMapped]
        public IFormFile Imagem { get; set; }

        public string UrlImagem { get; set; } = "FotoPadrao.png";

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }

}
