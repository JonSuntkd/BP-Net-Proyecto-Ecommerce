using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Dominio.Entities;

namespace Curso.ComercioElectronico.Aplicacion.Services
{
    public interface IDeliveryMethodAppService
    {   
        Task<ICollection<DeliveryMethodDto>> GetAllAsync();
        Task<DeliveryMethodDto> GetAsync(Guid id);
        Task CreateAsync(CreateUpdateDeliveryMethodDto deliveryMethodDto);
        Task UpdateAsync(CreateUpdateDeliveryMethodDto deliveryMethodDto);
        Task DeleteAsync(Guid id);
    }

}
