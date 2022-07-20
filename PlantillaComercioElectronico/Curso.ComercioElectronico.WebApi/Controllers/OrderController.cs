using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ComercioElectronico.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase, IOrderAppService
    {
        private readonly IOrderAppService order;
        public OrderController(IOrderAppService order)
        {
            this.order = order;
        }
        [HttpPost("AddOrder")]
        public Task<bool> AddOrder(CreateUpdateOrderDto orderDto)
        {
            return order.AddOrder(orderDto);
        }
        [HttpPost("AddProduct")]
        public Task<OrderItemDto> AddProductOrder(CreateUpdateOrderItemDto orderItemDto)
        {
            return order.AddProductOrder(orderItemDto);
        }
        [HttpDelete("DeleteProduct")]
        public Task<bool> DeleteItemOrder(Guid Id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("OrderView")]
        public Task<Order> ViewOrder()
        {
            return order.ViewOrder();
        }
    }
}
