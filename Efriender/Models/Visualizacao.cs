using EFriender.Models;
using Microsoft.AspNetCore.Identity;
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
            this.usuarioVisualizador = usuarioVisualizador;
            this.usuarioVisto = usuarioVisto;
        }

        public Visualizacao(Usuario usuarioVisualizador, Usuario usuarioVisto, bool like)
        {
            this.usuarioVisualizador = usuarioVisualizador;
            this.usuarioVisto = usuarioVisto;
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
        public Usuario usuarioVisualizador { get; set; }
        public Usuario usuarioVisto { get; set; }

        #endregion

    }
}