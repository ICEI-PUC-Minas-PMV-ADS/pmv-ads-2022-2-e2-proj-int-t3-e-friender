using Efriender.Models;
using EFriender.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Efriender.Data;

public class ApplicationDbContext : IdentityDbContext<Usuario>
{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Jogo> Jogos { get; set; }
    public DbSet<Visualizacao> Visualizacoes { get; set; }
    public DbSet<Combinacao> Combinacoes { get; set; }

}
