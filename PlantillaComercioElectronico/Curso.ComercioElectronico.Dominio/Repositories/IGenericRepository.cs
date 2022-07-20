using Curso.ComercioElectronico.Dominio.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Dominio.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Listar todos los objetos de una entidad que se declara al inicializar el repositorio
        /// </summary>
        /// <returns></returns>
        Task<ICollection<T>> GetAsync();

        /// <summary>
        /// Obtener un objeto Queryable
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetQueryable();

        /// <summary>
        /// Obtener un objeto por su clave primaria de tipo string
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<T> GetAsync(string code);

        /// <summary>
        /// Obtener un objeto por su clave primaria de tipo Guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetAsync(Guid id);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);
        
        Task DeleteAsync(T entity);
    }
}
