using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Curso.ComercioElectronico.Aplicacion.AddServices
{
    public static class DominioServiceCollectionExtensions
    {
        public static IServiceCollection AddDominio(this IServiceCollection services, IConfiguration config)
        {
            return services;
        }
    }
}
