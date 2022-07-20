using AutoMapper;
using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Exceptions;
using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Curso.ComercioElectronico.Dominio.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Aplicacion.ServicesImpl
{
    public class BrandAppService : IBrandAppService
    {
        private readonly IGenericRepository<Brand> repository;
        private readonly IValidator<CreateUpdateBrandDto> validator;
        public IMapper mapper { get; }

        public BrandAppService(IGenericRepository<Brand> repository, IValidator<CreateUpdateBrandDto> validator, IMapper mapper)
        {
            this.repository = repository;
            this.validator = validator;
            this.mapper = mapper;
        }

        public async Task<ICollection<BrandDto>> GetAllAsync()
        {
            var query= await repository.GetAsync();

            var list = new List<BrandDto>();
            foreach (var item in query)
            {
                list.Add(mapper.Map<BrandDto>(item));
            }

            return list;
        }

        public async Task<BrandDto> GetAsync(string code)
        {
            var entity = await repository.GetAsync(code);
            return new BrandDto
            {
                Code = entity.Code,
                Description = entity.Description,
                CreationDate = entity.CreationDate
            };
        }

        public async Task CreateAsync(CreateUpdateBrandDto brandDto)
        {
            await validator.ValidateAndThrowAsync(brandDto);

            var brand = mapper.Map<Brand>(brandDto);
            brand.CreationDate = DateTime.Now;

            await repository.CreateAsync(brand);

        }

        public async Task UpdateAsync(CreateUpdateBrandDto brandDto)
        {
            var entity = await repository.GetAsync(brandDto.Code);
            if (entity == null)
            {
                throw new NotFoundException($"La entidad con código: {brandDto.Code} no existe");
                //throw new Exception($"La entidad con código: {brandDto.Code} no existe");
            }
            entity.Description = brandDto.Description;
            entity.ModifiedDate = DateTime.Now;

            await repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(string code)
        {
            var entity = await repository.GetAsync(code);
            if (entity == null)
            {
                throw new NotFoundException($"La entidad con código: {code} no existe");
                //throw new Exception($"La entidad con código: {code} no existe");
            }

            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.Now;

            await repository.UpdateAsync(entity);
        }

        public async Task<ResultPaginationBrand<BrandDto>> GetListAsync(string? searchCode = "", string? searchDescription = "", int offset = 0, int limit = 10, string sort = "Description", string order = "asc")
        {
            var query = repository.GetQueryable();

            //Filtrando los no eliminados
            query = query.Where(x => x.IsDeleted == false);

            //Search
            if ((!string.IsNullOrEmpty(searchCode)) && (!string.IsNullOrEmpty(searchDescription)))
            {
                query = query.Where(x => (x.Code.ToUpper().Contains(searchCode) && x.Description.ToUpper().Contains(searchDescription)));
            }

            //1
            var total = await query.CountAsync();
            //2
            query = query.Skip(offset).Take(limit);
            //3
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToUpper())
                {
                    case "DESCRIPTION":
                        query = query.OrderBy(x => x.Description);
                        break;
                    
                    default:
                        throw new ArgumentException($"The parameter sort {sort} not sopport");
                }
            }

            var queryDto = query.Select(x => new BrandDto
            {
                Code = x.Code,
                Description = x.Description,
                CreationDate = x.CreationDate
            });
            var items = await queryDto.ToListAsync();
            var result = new ResultPaginationBrand<BrandDto>();
            result.Total = total;
            result.Items = items;

            return result;

        }
    }
}
