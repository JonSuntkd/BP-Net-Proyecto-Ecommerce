using Curso.ComercioElectronico.Aplicacion;
using Curso.ComercioElectronico.Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ComercioElectronico.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CatalogoController : ControllerBase, ICatalogoAplicacion
    {
        private readonly ICatalogoAplicacion catalogoAplicacion;

        public CatalogoController(ICatalogoAplicacion catalogoAplicacion)
        {
            this.catalogoAplicacion = catalogoAplicacion;
        }

        [HttpGet]
        public Task<ICollection<Catalogo>> GetAsync()
        {
            return catalogoAplicacion.GetAsync();
        }
    }
}
