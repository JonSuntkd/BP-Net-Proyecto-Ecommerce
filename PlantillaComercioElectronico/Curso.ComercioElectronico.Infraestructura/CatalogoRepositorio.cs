using Curso.ComercioElectronico.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Infraestructura
{

    public class CatalogoRepositorio : ICatalogoRepositorio
    {
        private readonly ComercioElectronicoDbContext context;

        public CatalogoRepositorio(ComercioElectronicoDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<Catalogo>> ObtenerAsync()
        {

            return await context.Catalogos.ToListAsync();

        }
    }


    public class CatalogoRepositorioMock : ICatalogoRepositorio
    {

        public async Task<ICollection<Catalogo>> ObtenerAsync()
        {
            var lista = new List<Catalogo>();
            lista.Add(new Catalogo { Id = "Foo", Nombre = "Bar" });

            return await Task.FromResult(lista);


        }

    }
}