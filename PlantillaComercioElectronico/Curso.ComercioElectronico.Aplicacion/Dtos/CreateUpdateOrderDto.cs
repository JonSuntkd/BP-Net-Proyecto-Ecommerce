using Curso.ComercioElectronico.Dominio.Entities;

namespace Curso.ComercioElectronico.Aplicacion.Dtos
{
    public class CreateUpdateOrderDto
    {
        public string? DeliveryMethodId { get; set; }
        public string? ClientInvoiceId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}
