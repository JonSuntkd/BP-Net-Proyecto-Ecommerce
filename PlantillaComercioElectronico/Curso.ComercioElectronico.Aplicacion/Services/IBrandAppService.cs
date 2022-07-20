using Curso.ComercioElectronico.Aplicacion.Dtos;

namespace Curso.ComercioElectronico.Aplicacion.Services
{
    public interface IBrandAppService
    {
        Task<ICollection<BrandDto>> GetAllAsync();
        Task<ResultPaginationBrand<BrandDto>> GetListAsync(string? searchCode = "", string? searchDescription = "", int offset = 0, int limit = 10, string sort = "Description", string order = "asc");
        Task<BrandDto> GetAsync(string code);
        Task CreateAsync(CreateUpdateBrandDto brandDto);
        Task UpdateAsync(CreateUpdateBrandDto brandDto);
        Task DeleteAsync(string code);
    }
    public class ResultPaginationBrand<T>
    {
        public int Total { get; set; }
        public ICollection<T> Items { get; set; } = new List<T>();
    }
}
