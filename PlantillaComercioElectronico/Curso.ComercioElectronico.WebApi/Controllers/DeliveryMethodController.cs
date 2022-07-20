using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ComercioElectronico.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryMethodController : ControllerBase, IDeliveryMethodAppService
    {
        private readonly IDeliveryMethodAppService deliveryMethodAppService;

        public DeliveryMethodController(IDeliveryMethodAppService deliveryMethodAppService)
        {
            this.deliveryMethodAppService = deliveryMethodAppService;
        }
        [HttpPost]
        public Task CreateAsync(CreateUpdateDeliveryMethodDto deliveryMethodDto)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("{id}")]
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public Task<ICollection<DeliveryMethodDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id}")]
        public Task<DeliveryMethodDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        public Task UpdateAsync(CreateUpdateDeliveryMethodDto deliveryMethodDto)
        {
            throw new NotImplementedException();
        }
    }
}
