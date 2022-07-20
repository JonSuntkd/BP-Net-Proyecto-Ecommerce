using Curso.ComercioElectronico.Aplicacion.Dtos;

namespace Curso.ComercioElectronico.Aplicacion.Services
{
    public interface IProductTypeAppService
    {

        Task<ICollection<ProductTypeDto>> GetAllAsync();
        Task<ProductTypeDto> GetAsync(string code);
        Task CreateAsync(CreateUpdateProductTypeDto productTypeDto);
        Task UpdateAsync(CreateUpdateProductTypeDto productTypeDto);
        Task DeleteAsync(string code);
    }
}
