﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace EFriender.Models
{
    [Table("Usuário")]
    public class Usuario

    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório inserir a Imagem do Jogo")]
        [Display(Name = "Imagem")]
        [NotMapped]
        public IFormFile Imagem { get; set; }

        public string UrlImagem { get; set; } = "FotoPadrao.png";

        [Required(ErrorMessage = "Obrigatório informar o nome!")]
        public string Nome { get; set; }

        public int Idade { get; set; }

        [Display(Name ="Gênero")]
        public Generos Genero { get; set; }

        public enum Generos
        {
            Masculino,
            Feminino,
        }

        public string Nick { get; set; }

        public string Discord { get; set; }

        public string Curso { get; set; }

        public string Faculdade { get; set; }

        [Display(Name ="Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Preferências")]
        public string Preferencias { get; set; }

        [Display(Name ="Jogos")]
        [ForeignKey("Jogos")]
        public int JogosId { get; set; }

       public Jogos Jogos { get; set; }

    }
}