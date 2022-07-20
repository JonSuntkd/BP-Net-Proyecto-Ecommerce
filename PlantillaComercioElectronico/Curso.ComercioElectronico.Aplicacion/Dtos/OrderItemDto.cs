namespace Curso.ComercioElectronico.Aplicacion.Dtos
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public string Product { get; set; }
        public string Order { get; set; }
        public int ProductQuantity { get; set; } = 1;
        public decimal Total { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
