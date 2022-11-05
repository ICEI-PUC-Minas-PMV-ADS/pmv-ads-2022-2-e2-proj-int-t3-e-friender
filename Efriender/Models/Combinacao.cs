using EFriender.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Efriender.Models
{
    [Table("Combinaçoes")]
    public class Combinacao
    {

        [Key]
        public int Id { get; set; }
        public int Id_Usuario1 { get; set; }
        public Usuario? usuarioCurtido1 { get; set; }
        public int Id_Usuario2 { get; set; }
        public Usuario? usuarioCurtido2 { get; set; }


    }
}
