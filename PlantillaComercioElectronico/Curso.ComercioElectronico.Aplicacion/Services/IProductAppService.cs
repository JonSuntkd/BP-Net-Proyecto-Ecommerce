using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Dominio.Entities;

namespace Curso.ComercioElectronico.Aplicacion.Services
{
    public interface IProductAppService
    {   
        Task<ICollection<ProductDto>> GetAllAsync();
        Task<ResultPagination<ProductDto>> GetListAsync(string? searchName="", string? searchProductType = "", int offset=0, int limit=10, string sort="Name", string order="asc");
        Task<ProductDto> GetAsync(Guid id);
        Task CreateAsync(CreateUpdateProductDto productDto);
        Task UpdateAsync(Guid id, CreateUpdateProductDto productDto);
        Task DeleteAsync(Guid id);
    }

    public class ResultPagination<T>
    {
        public int Total { get; set; }
        public ICollection<T> Items { get; set; } = new List<T>();
    }
}
