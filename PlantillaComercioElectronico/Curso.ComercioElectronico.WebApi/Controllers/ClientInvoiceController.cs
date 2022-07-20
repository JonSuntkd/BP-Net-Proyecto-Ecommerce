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
    public class ClientInvoiceController : ControllerBase, IClientInvoiceAppService
    {
        private readonly IClientInvoiceAppService clientInvoiceAppService;
        public ClientInvoiceController(IClientInvoiceAppService clientInvoiceAppService)
        {
            this.clientInvoiceAppService = clientInvoiceAppService;
        }
        [HttpPost]
        public async Task CreateAsync(CreateUpdateClientInvoiceDto clientInvoiceDto)
        {
            await clientInvoiceAppService.CreateAsync(clientInvoiceDto);
        }
        [HttpDelete("{code}")]
        public async Task DeleteAsync(string code)
        {
            await clientInvoiceAppService.DeleteAsync(code);
        }
        [HttpGet]
        public async Task<ICollection<ClientInvoiceDto>> GetAllAsync()
        {
            return await clientInvoiceAppService.GetAllAsync();
        }
        [HttpGet("{code}")]
        public async Task<ClientInvoiceDto> GetAsync(string code)
        {
            return await clientInvoiceAppService.GetAsync(code);
        }
        [HttpPut]
        public async Task UpdateAsync(ClientInvoiceDto clientInvoiceDto)
        {
            await clientInvoiceAppService.UpdateAsync(clientInvoiceDto);
        }
    }
}
