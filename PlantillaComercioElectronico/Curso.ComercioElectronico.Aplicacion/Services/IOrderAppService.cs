using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Dominio.Entities;

namespace Curso.ComercioElectronico.Aplicacion.Services
{
    public interface IOrderAppService
    {
        Task<bool> AddOrder(CreateUpdateOrderDto orderDto);
        Task<OrderItemDto> AddProductOrder(CreateUpdateOrderItemDto orderItemDto);
        Task<bool> DeleteItemOrder(Guid Id);
        Task<Order> ViewOrder();
    }
}
