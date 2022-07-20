using Curso.ComercioElectronico.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Curso.ComercioElectronico.Infraestructura.EntityConfigurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .IsRequired();

            builder.Property(b => b.ProductQuantity)
                .IsRequired();

            builder.Property(b => b.Total)
                .HasColumnType("decimal(18,2)");
            
            builder.HasOne(b => b.Product)
                .WithMany()
                .HasForeignKey(b => b.ProductId);

            builder.HasOne(b => b.Order)
                .WithMany()
                .HasForeignKey(b => b.OrderId);


            builder.Property(b => b.IsDeleted).IsRequired();

        }
    }
}
