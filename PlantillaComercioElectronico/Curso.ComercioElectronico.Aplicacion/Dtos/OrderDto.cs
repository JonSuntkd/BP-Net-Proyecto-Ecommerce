using Curso.ComercioElectronico.Dominio.Entities;

namespace Curso.ComercioElectronico.Aplicacion.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string? DeliveryMethod { get; set; }
        public string? ClientInvoice { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}
