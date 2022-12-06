using EFriender.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Efriender.Models
{
    [Table("Combinaçoes")]
    public class Combinacao
    {
        #region [ CONSTRUTORES ]

        public Combinacao(Usuario usuario1, Usuario usuario2)
        {
            this.usuario1 = usuario1;
            this.usuario2 = usuario2;
        }
        public Combinacao() { }

        #endregion

        #region [ ATRIBUTOS ]

        [Key]
        public int Id { get; set; }
        public Usuario usuario1 { get; set; }
        public Usuario usuario2 { get; set; }

        #endregion 
    }
}



//public Usuario? usuarioCurtido2 { get; set; }
//public Usuario? usuarioCurtido1 { get; set; }
