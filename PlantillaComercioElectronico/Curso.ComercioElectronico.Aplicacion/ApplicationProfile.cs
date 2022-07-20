using AutoMapper;
using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Dominio.Entities;

namespace Curso.ComercioElectronico.Aplicacion
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<ProductTypeDto, ProductType>();
            CreateMap<BrandDto, Brand>();
            CreateMap<CreateUpdateBrandDto, Brand>();
            CreateMap<CreateUpdateProductDto, Product>();
            CreateMap<CreateUpdateProductTypeDto, ProductType>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductType, ProductTypeDto>();
            CreateMap<Brand, BrandDto>();
            CreateMap<Brand, CreateUpdateBrandDto> ();
            CreateMap<Product, CreateUpdateProductDto>();
            CreateMap<ProductType, CreateUpdateProductTypeDto>();

            CreateMap<ClientInvoiceDto, ClientInvoice>();
            CreateMap<ClientInvoice, ClientInvoiceDto>();
            CreateMap<CreateUpdateClientInvoiceDto, ClientInvoice>();
            CreateMap<ClientInvoice, CreateUpdateClientInvoiceDto>();

            CreateMap<DeliveryMethodDto, DeliveryMethod>();
            CreateMap<DeliveryMethod, DeliveryMethodDto>();
            CreateMap<CreateUpdateDeliveryMethodDto, DeliveryMethod>();
            CreateMap<DeliveryMethod, CreateUpdateDeliveryMethodDto>();

            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>();
            CreateMap<CreateUpdateOrderDto, Order>();
            CreateMap<Order, CreateUpdateOrderDto>();

            CreateMap<OrderItemDto, OrderItem>();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<CreateUpdateOrderItemDto, OrderItem>();
            CreateMap<OrderItem, CreateUpdateOrderItemDto>();
        }
    }
}
