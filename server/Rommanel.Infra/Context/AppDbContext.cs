using Microsoft.EntityFrameworkCore;
using Rommanel.Domain.Models;

namespace Rommanel.Infra.Context;

public class AppDbContext : DbContext
{
    public virtual DbSet<ClienteModel> Clientes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClienteModel>().OwnsOne(c => c.Endereco);
        base.OnModelCreating(modelBuilder);
    }
}
