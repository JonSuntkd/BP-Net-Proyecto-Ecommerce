using Curso.ComercioElectronico.Aplicacion.Dtos;

namespace Curso.ComercioElectronico.Aplicacion.Services
{
    public interface IClientInvoiceAppService
    {
        Task<ICollection<ClientInvoiceDto>> GetAllAsync();
        Task<ClientInvoiceDto> GetAsync(string code);
        Task CreateAsync(CreateUpdateClientInvoiceDto clientInvoiceDto);
        Task UpdateAsync(ClientInvoiceDto clientInvoiceDto);
        Task DeleteAsync(string code);
    }
}
