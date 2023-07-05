using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoBancoFinal.Areas.Identity.Data;
using ProjetoBancoFinal.Models;

namespace ProjetoBancoFinal.Areas.Identity.Data;

public class BancoXPTOContext : IdentityDbContext<Cliente>
{
    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<Conta> Contas { get; set; }

    public DbSet<ChavePix> ChavesPix { get; set; }

    public BancoXPTOContext(DbContextOptions<BancoXPTOContext> options): base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ContaCorrente>();
        builder.Entity<ContaPoupanca>();

        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
