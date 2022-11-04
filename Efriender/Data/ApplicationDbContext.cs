using EFriender.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Efriender.Data;

public class ApplicationDbContext : IdentityDbContext
{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Jogos> Jogos { get; set; }

    // implementar referencias para as tabelas de like e match
}
