using Curso.ComercioElectronico.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Curso.ComercioElectronico.Infraestructura.EntityConfigurations
{
    public class ClientInvoiceConfiguration : IEntityTypeConfiguration<ClientInvoice>
    {
        public void Configure(EntityTypeBuilder<ClientInvoice> builder)
        {
            builder.ToTable("ClientInvoices");
                builder.HasKey(b => b.Id);
                
            builder.Property(b => b.Id)
                .IsRequired();

            builder.Property(b => b.Name)
                .HasMaxLength(256)
                .IsRequired();
            builder.Property(b => b.PhoneNumber)
                .HasMaxLength(10)
                .IsRequired();
            builder.Property(b => b.IdentificationCard)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
