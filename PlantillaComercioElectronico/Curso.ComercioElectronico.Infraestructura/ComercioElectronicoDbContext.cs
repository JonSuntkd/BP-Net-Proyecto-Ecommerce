using Curso.ComercioElectronico.Dominio;
using Curso.ComercioElectronico.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Curso.ComercioElectronico.Infraestructura
{
    public class ComercioElectronicoDbContext : DbContext {
        public ComercioElectronicoDbContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<Catalogo> Catalogos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ClientInvoice> ClientInvoices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}