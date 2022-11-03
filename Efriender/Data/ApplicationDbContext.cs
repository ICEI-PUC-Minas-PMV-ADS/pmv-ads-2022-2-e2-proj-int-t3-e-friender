using Efriender.Areas.Identity;
using Efriender.Areas.Identity.Pages.Account;
using EFriender.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Efriender.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<Usuario> Usuario { get; set; }

    public DbSet<Jogos> Jogos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(128));
        modelBuilder.Entity<IdentityRole>(entity => entity.Property(m => m.Id).HasMaxLength(128));

        modelBuilder.Entity<IdentityRole>().Property(r => r.Id).HasMaxLength(128);
        modelBuilder.Entity<IdentityRole>().Property(r => r.Name).HasMaxLength(128);
        modelBuilder.Entity<IdentityRole>().Property(r => r.NormalizedName).HasMaxLength(128);
        modelBuilder.Entity<IdentityRole>().Property(r => r.ConcurrencyStamp).HasMaxLength(128);

        modelBuilder.Entity<IdentityUser>().Property(r => r.Id).HasMaxLength(128);
        modelBuilder.Entity<IdentityUser>().Property(r => r.UserName).HasMaxLength(128);
        modelBuilder.Entity<IdentityUser>().Property(r => r.NormalizedUserName).HasMaxLength(128);
        modelBuilder.Entity<IdentityUser>().Property(r => r.Email).HasMaxLength(128);
        modelBuilder.Entity<IdentityUser>().Property(r => r.NormalizedEmail).HasMaxLength(128);
        modelBuilder.Entity<IdentityUser>().Property(r => r.EmailConfirmed).HasMaxLength(128);
        modelBuilder.Entity<IdentityUser>().Property(r => r.PasswordHash).HasMaxLength(128);
        modelBuilder.Entity<IdentityUser>().Property(r => r.SecurityStamp).HasMaxLength(128);
        modelBuilder.Entity<IdentityUser>().Property(r => r.ConcurrencyStamp).HasMaxLength(128);
        modelBuilder.Entity<IdentityUser>().Property(r => r.PhoneNumber).HasMaxLength(128);
        modelBuilder.Entity<IdentityUser>().Property(r => r.PhoneNumberConfirmed).HasMaxLength(128);
        modelBuilder.Entity<IdentityUser>().Property(r => r.TwoFactorEnabled).HasMaxLength(128);
        modelBuilder.Entity<IdentityUser>().Property(r => r.LockoutEnd).HasMaxLength(128);
        modelBuilder.Entity<IdentityUser>().Property(r => r.LockoutEnabled).HasMaxLength(128);
        modelBuilder.Entity<IdentityUser>().Property(r => r.AccessFailedCount).HasMaxLength(128);


        modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(128));
        modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(128));
        modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(128));
        modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(128));
        modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderDisplayName).HasMaxLength(128));



        modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(128));
        modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(128));


        modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(128));
        modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(128));
        modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name).HasMaxLength(128));

        modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(128));
        modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(128));
    }

}
