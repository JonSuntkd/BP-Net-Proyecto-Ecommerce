using Curso.ComercioElectronico.Dominio.Entities.Base;

namespace Curso.ComercioElectronico.Dominio.Entities
{
    public class Order : BaseBusinessEntity
    {
        public Guid? DeliveryMethodId { get; set; }
        public DeliveryMethod? DeliveryMethod { get; set; }
        public Guid? ClientInvoiceId { get; set; }
        public ClientInvoice? ClientInvoice { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}
