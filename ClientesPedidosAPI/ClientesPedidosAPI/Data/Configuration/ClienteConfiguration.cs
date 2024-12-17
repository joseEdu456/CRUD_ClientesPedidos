using ClientesPedidosAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientesPedidosAPI.Data.Configuration;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Clientes");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Nome).HasMaxLength(50).IsRequired();
        builder.Property(c => c.Email).HasMaxLength(50).IsRequired();
        builder.Property(c => c.Telefone).HasMaxLength(50).IsRequired();
    }
}