using Efriender.Models;
using EFriender.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Efriender.Data;

public class ApplicationDbContext : IdentityDbContext
{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        // -- segundo metodo para configuração das Foreign Keys
        builder.Entity<Visualizacao>()
            .HasOne(x => x.usuarioVisualizador)
            .WithMany(x => x.VisualizacoesRealizadas)
            .HasForeignKey(x => x.Id_visualizador);

        builder.Entity<Visualizacao>()
            .HasOne(x => x.usuarioVisto)
            .WithMany(x => x.VisualizacoesRecebidas)
            .HasForeignKey(x => x.Id_visto);

        builder.Entity<Combinacao>()
            .HasOne(x => x.usuarioCurtido1)
            .WithMany(x => x.UsuarioPrimario)
            .HasForeignKey(x => x.Id_Usuario1);

        builder.Entity<Combinacao>()
            .HasOne(x => x.usuarioCurtido2)
            .WithMany(x => x.UsuarioSecundario)
            .HasForeignKey(x => x.Id_Usuario2);
    }



    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Jogos> Jogos { get; set; }
    public DbSet<Visualizacao> Visualizacao { get; set; }
    public DbSet<Combinacao> Combinacoes { get; set; }

    // implementar referencias para as tabelas de like e match
}
