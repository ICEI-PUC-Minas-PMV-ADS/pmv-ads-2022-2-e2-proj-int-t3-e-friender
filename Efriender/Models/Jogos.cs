using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace EFriender.Models
{
    [Table("Jogos")]
    public class Jogos
    {
        
        [Key]
        public int Id { get; set; }

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
