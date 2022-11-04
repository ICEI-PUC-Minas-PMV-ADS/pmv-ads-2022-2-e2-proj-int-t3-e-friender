using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace EFriender.Models
{
    [Table("Usuário")]
    public class Usuario

    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório inserir a Imagem de Perfil")]
        [Display(Name = "Imagem")]
        [NotMapped]
        public IFormFile Imagem { get; set; }

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

        [Display(Name = "Jogo 2")]
        public JogoSecundario? JogoSecond { get; set; }

        public enum JogoSecundario
        {
            Nenhum,
            Outlast,
            Pokemon,
            [Display(Name="Monster Hunter")]
            MonsterHunter,
        }


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


    }
}
