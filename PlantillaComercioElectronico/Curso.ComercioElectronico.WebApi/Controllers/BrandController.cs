using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ComercioElectronico.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase, IBrandAppService
    {
        private readonly IBrandAppService brandAppService;

        public BrandController(IBrandAppService brandAppService)
        {
            this.brandAppService = brandAppService;
        }

        [HttpGet]
        public async Task<ICollection<BrandDto>> GetAllAsync()
        {
            return await brandAppService.GetAllAsync();
        }

        [HttpGet("{code}")]
        public async Task<BrandDto> GetAsync(string code)
        {
            return await brandAppService.GetAsync(code);
        }

        [HttpPost]
        public async Task CreateAsync(CreateUpdateBrandDto brandDto)
        {   
            await brandAppService.CreateAsync(brandDto);
        }

        [HttpPut]
        public async Task UpdateAsync(CreateUpdateBrandDto brandDto)
        {
            await brandAppService.UpdateAsync(brandDto);
        }

        [HttpDelete("{code}")]
        public async Task DeleteAsync(string code)
        {
            await brandAppService.DeleteAsync(code);
        }
        [HttpGet("Paginacion-buscar-ordenamiento-brand")]
        public async Task<ResultPaginationBrand<BrandDto>> GetListAsync(string? searchCode = "", string? searchDescription = "", int offset = 0, int limit = 10, string sort = "Description", string order = "asc")
        {
            return await brandAppService.GetListAsync(searchCode, searchDescription, offset, limit, sort, order);
        }
    }
}
