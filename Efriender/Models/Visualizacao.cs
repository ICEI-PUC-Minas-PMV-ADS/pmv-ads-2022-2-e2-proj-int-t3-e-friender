﻿using EFriender.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Efriender.Models
{
    [Table("Visualizações")]
    public class Visualizacao
    {

        #region [ CONSTRUTORES ]

        public Visualizacao(int ID_Visualizador, int ID_Visto)
        {
            this.Id_visualizador = ID_Visualizador;
            this.Id_visto = ID_Visto;
        }

        public Visualizacao(int ID_Visualizador, int ID_Visto, bool like)
        {
            this.Id_visualizador = ID_Visualizador;
            this.Id_visto = ID_Visto;
            this.like = like;
        }

        public Visualizacao()
        {
   
        }

        #endregion



        [Key]
        public int Id { get; set; }
        public bool like { get; set; }
        public int Id_visualizador { get; set; }
        
        [ForeignKey("Id_visualizador")]
        public Usuario usuarioVisualizador { get; set; }

        public int Id_visto { get; set; }
        
        [ForeignKey("Id_visto")]
        public Usuario usuarioVisto { get; set; }

    }
}
