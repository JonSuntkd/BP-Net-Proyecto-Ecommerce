namespace Curso.ComercioElectronico.Aplicacion.Dtos
{
    public class CreateUpdateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductTypeId { get; set; }
        public string BrandId { get; set; }
    }
}
