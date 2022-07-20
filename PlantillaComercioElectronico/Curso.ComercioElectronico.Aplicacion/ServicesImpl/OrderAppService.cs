using AutoMapper;
using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Curso.ComercioElectronico.Dominio.Repositories;

namespace Curso.ComercioElectronico.Aplicacion.ServicesImpl
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IGenericRepository<OrderItem> repositoryOrderItem;
        private readonly IGenericRepository<Order> repositoryOrder;
        private readonly IMapper mapper;
        private readonly IProductAppService product;

        public OrderAppService(IGenericRepository<OrderItem> repositoryOrderItem, IGenericRepository<Order> repositoryOrden, IMapper mapper, IProductAppService producto)
        {
            this.repositoryOrderItem = repositoryOrderItem;
            this.repositoryOrder = repositoryOrden;
            this.mapper = mapper;
            this.product = producto;
        }

        public async Task<bool> AddOrder(CreateUpdateOrderDto orderDto)
        {
            var order = mapper.Map<Order>(orderDto);
            order.Id = Guid.NewGuid();
            order.OrderItems = (List<OrderItem>?)await repositoryOrderItem.GetAsync();
            order.Subtotal = 0;
            
            foreach (var item in order.OrderItems)
            {
                item.Product = mapper.Map<Product>(await product.GetAsync(item.ProductId));
                order.Subtotal = order.Subtotal + item.Product.Price;
            }

            order.TotalPrice = order.Subtotal * (1 + (12 / 100));

            if (order.OrderItems.Count() <= 0)
            {
                throw new ArgumentException("No hay objetos para añadir al carro de compras");
            }

            await repositoryOrder.CreateAsync(order);
            return true;
        }

        public async Task<OrderItemDto> AddProductOrder(CreateUpdateOrderItemDto orderItemDto)
        {
            
            var orderItems = mapper.Map<OrderItem>(orderItemDto);
            orderItems.Id = Guid.NewGuid();
            orderItems.CreationDate = DateTime.Now;

            var produc = mapper.Map<Product>(await product.GetAsync(orderItems.ProductId));

            orderItems.Product = produc;

            await repositoryOrderItem.CreateAsync(orderItems);

            var orderItemsMapp = mapper.Map<OrderItemDto>(orderItems);
            orderItemsMapp.Product = produc.Name;

            var addProduct = mapper.Map<CreateUpdateProductDto>(product);
            await product.UpdateAsync(produc.Id, addProduct);

            return orderItemsMapp;
        }

        public async Task<bool> DeleteItemOrder(Guid Id)
        {
            var orderItem = await repositoryOrderItem.GetAsync(Id);
            await repositoryOrderItem.DeleteAsync(orderItem);
            return true;
        }

        public async Task<Order> ViewOrder()
        {
            var orderConsulta = repositoryOrder.GetQueryable();
            var order = orderConsulta.FirstOrDefault();
            if (order == null)
            {
                throw new ArgumentException("No se a creado el carro de compras");
            }
            order.OrderItems = (List<OrderItem>?) await repositoryOrderItem.GetAsync();
            foreach (var item in order.OrderItems)
            {
                mapper.Map<Product>(await product.GetAsync(item.ProductId));
                var produc = mapper.Map<Product>(await product.GetAsync(item.ProductId));
                item.Product = produc;
            }
            return order;
        }
    }
}
