using Curso.ComercioElectronico.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Curso.ComercioElectronico.Infraestructura.EntityConfigurations
{
    public class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.ToTable("DeliveryMethods");
            
            builder.HasKey(b => b.Id);
            
            builder.Property(b => b.Id)
                    .IsRequired();

            builder.Property(b => b.Description)
                    .HasMaxLength(256)
                    .IsRequired();

            builder.Property(b => b.Name)
                    .HasMaxLength(256)
                    .IsRequired();
        }
    }
}
