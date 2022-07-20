using Curso.ComercioElectronico.Dominio;
using Curso.ComercioElectronico.Dominio.Repositories;
using Curso.ComercioElectronico.Infraestructura;
using Curso.ComercioElectronico.Infraestructura.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Curso.ComercioElectronico.Aplicacion.AddServices
{
    public static class InfraestructuraServiceCollectionExtensions
    {
        public static IServiceCollection AddInfraestructura(this IServiceCollection services, IConfiguration config)
        {
            //Agregar conexion a base de datos
            services.AddDbContext<ComercioElectronicoDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("ComercioElectronico"));
            });
            //Repositorios
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ICatalogoRepositorio, CatalogoRepositorio>();
           
            return services;
        }
    }
}
