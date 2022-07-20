using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Aplicacion.ServicesImpl;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Curso.ComercioElectronico.Aplicacion.AddServices
{
    public static class AplicacionServiceCollectionExtensions
    {
        public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration config)
        {
     
            //Servicios de aplicacion
            services.AddTransient(typeof(ICatalogoAplicacion), typeof(CatalogoAplicacion));
            services.AddTransient<IProductAppService, ProductAppService>();
            services.AddTransient<IBrandAppService, BrandAppService>();
            services.AddTransient<IProductTypeAppService, ProductTypeAppService>();
            services.AddTransient<IOrderAppService, OrderAppService>();
            services.AddTransient<IClientInvoiceAppService, ClientInvoiceAppService>();
            //services.AddTransient<IDeliveryMethodAppService, DeliveryMethodAppService>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            return services;
        }
    }
}
