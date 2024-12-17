using ClientesPedidosAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientesPedidosAPI.Data.Configuration;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("Pedidos");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Data).HasColumnType("datetime").IsRequired();
        builder.Property(p =>p.ValorTotal).HasColumnType("decimal(10, 2)").IsRequired();
    }
}