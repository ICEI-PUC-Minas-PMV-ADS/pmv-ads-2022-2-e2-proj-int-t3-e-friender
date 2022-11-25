using EFriender.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Efriender.Models
{
    [Table("Combinaçoes")]
    public class Combinacao
    {
        #region [ CONSTRUTORES ]

        public Combinacao(int ID_Usuario1, int ID_Usuario2)
        {
            Id_Usuario1 = ID_Usuario1;
            Id_Usuario2 = ID_Usuario2;
        }
        public Combinacao() { }

        #endregion

        #region [ ATRIBUTOS ]

        [Key]
        public int Id { get; set; }
        public int Id_Usuario1 { get; set; }
        public int Id_Usuario2 { get; set; }

        #endregion 
    }
}



//public Usuario? usuarioCurtido2 { get; set; }
//public Usuario? usuarioCurtido1 { get; set; }
