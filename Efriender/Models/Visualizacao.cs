using EFriender.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Efriender.Models
{
    [Table("Visualizações")]
    public class Visualizacao
    {
        [Key]
        public int Id { get; set; }
        public bool like { get; set; }
        public int Id_visualizador { get; set; }
        
        //[ForeignKey("Id_visualizador")]
        public Usuario? usuarioVisualizador { get; set; }

        public int Id_visto { get; set; }
        
        //[ForeignKey("Id_visto")]
        public Usuario? usuarioVisto { get; set; }

    }
}
