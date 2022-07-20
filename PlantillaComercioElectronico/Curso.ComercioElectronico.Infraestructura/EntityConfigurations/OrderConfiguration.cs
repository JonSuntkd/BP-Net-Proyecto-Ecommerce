using Curso.ComercioElectronico.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Curso.ComercioElectronico.Infraestructura.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .IsRequired();

            builder.Property(b => b.Subtotal)
                .HasColumnType("decimal(18,2)");
            builder.Property(b => b.TotalPrice)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(b => b.DeliveryMethod)
                .WithMany()
                .HasForeignKey(b => b.DeliveryMethodId);

            builder.HasOne(b => b.ClientInvoice)
                .WithMany()
                .HasForeignKey(b => b.ClientInvoiceId);


            builder.Property(b => b.IsDeleted).IsRequired();

        }
    }
}
