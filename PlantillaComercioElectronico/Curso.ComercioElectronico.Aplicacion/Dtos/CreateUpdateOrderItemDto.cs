namespace Curso.ComercioElectronico.Aplicacion.Dtos
{
    public class CreateUpdateOrderItemDto
    {
        public string ProductId { get; set; }
        public string OrderId { get; set; }
        public int ProductQuantity { get; set; } = 1;
        public decimal Total { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
