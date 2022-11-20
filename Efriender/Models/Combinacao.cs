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
            this.Id_Usuario1 = ID_Usuario1;
            this.Id_Usuario2 = ID_Usuario2;
        }

        #endregion 

        [Key]
        public int Id { get; set; }
        public int Id_Usuario1 { get; set; }
        public Usuario? usuarioCurtido1 { get; set; }
        public int Id_Usuario2 { get; set; }
        public Usuario? usuarioCurtido2 { get; set; }


    }
}
