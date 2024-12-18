using ClientesPedidosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientesPedidosAPI.Data;

public class AplicationContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public AplicationContext(DbContextOptions<AplicationContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data source=localhost\\SQLEXPRESS; Initial Catalog=ApiClientesPedidos; Integrated Security=true; TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AplicationContext).Assembly);
    }
}