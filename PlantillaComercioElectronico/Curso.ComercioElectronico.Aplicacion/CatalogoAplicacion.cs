using Curso.ComercioElectronico.Dominio;
using Curso.ComercioElectronico.Infraestructura;

namespace Curso.ComercioElectronico.Aplicacion
{
    /// <summary>
    /// Servicio de aplicacion, para los catalogos de productos
    /// </summary>
    public class CatalogoAplicacion: ICatalogoAplicacion
    {
        protected ICatalogoRepositorio CatalogoRepositorio { get; set; }

        public CatalogoAplicacion(ICatalogoRepositorio repositorio)
        {
            this.CatalogoRepositorio = repositorio;
        }

        public  Task<ICollection<Catalogo>> GetAsync() {

            return CatalogoRepositorio.ObtenerAsync();
        }
    }

}