using EFriender.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Efriender.Models
{
    [Table("Visualizações")]
    public class Visualizacao
    {

        #region [ CONSTRUTORES ]

        public Visualizacao(Usuario usuarioVisualizador, Usuario usuarioVisto)
        {
            this.Usuario_Visualizador = usuarioVisualizador;   
            this.Usuario_Visto = usuarioVisto;
        }

        public Visualizacao(Usuario usuarioVisualizador, Usuario usuarioVisto, bool like)
        {
            this.Usuario_Visualizador = usuarioVisualizador;
            this.Usuario_Visto = usuarioVisto;
            this.like = like;
        }

        public Visualizacao()
        {
   
        }

        #endregion

        #region [ ATRIBUTOS ]

        [Key]
        public int Id { get; set; }
        public bool like { get; set; }
        public Usuario Usuario_Visualizador { get; set; } // FK DE USUARIO
        public Usuario Usuario_Visto { get; set; } // FK DE USUARIO


        #endregion

    }
}




//[ForeignKey("Id_visto")]
//public Usuario? usuarioVisto { get; set; }

//[ForeignKey("Id_visualizador")]
//public Usuario? usuarioVisualizador { get; set; }