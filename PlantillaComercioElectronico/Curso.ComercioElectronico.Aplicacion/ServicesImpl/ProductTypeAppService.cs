using AutoMapper;
using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Curso.ComercioElectronico.Dominio.Repositories;
using FluentValidation;

namespace Curso.ComercioElectronico.Aplicacion.ServicesImpl
{
    public class ProductTypeAppService : IProductTypeAppService
    {
        private readonly IGenericRepository<ProductType> repository;
        private readonly IMapper mapper;
        private readonly IValidator<CreateUpdateProductTypeDto> validator;

        public ProductTypeAppService(IGenericRepository<ProductType> repository, IMapper mapper, IValidator<CreateUpdateProductTypeDto> validator)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task CreateAsync(CreateUpdateProductTypeDto productTypeDto)
        {
            await validator.ValidateAndThrowAsync(productTypeDto);
            var productType = mapper.Map<ProductType>(productTypeDto);
            productType.CreationDate = DateTime.Now;

            await repository.CreateAsync(productType);
        }

        public async Task DeleteAsync(string code)
        {
            var entity = await repository.GetAsync(code);
            if (entity == null)
            {
                throw new Exception($"La entidad con código: {code} no existe");
            }

            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.Now;

            await repository.UpdateAsync(entity);
        }

        public async Task<ICollection<ProductTypeDto>> GetAllAsync()
        {
            var query = await repository.GetAsync();
            var result = query.Select(x => new ProductTypeDto
            {
                Code = x.Code,
                Description = x.Description,
                CreationDate = x.CreationDate
            });

            return result.ToList();
        }

        public async Task<ProductTypeDto> GetAsync(string code)
        {
            var entity = await repository.GetAsync(code);
            return new ProductTypeDto {
                Code = entity.Code,
                Description = entity.Description,
                CreationDate = entity.CreationDate
            };
        }

        public async Task UpdateAsync(CreateUpdateProductTypeDto productTypeDto)
        {
            var entity = await repository.GetAsync(productTypeDto.Code);
            if (entity == null)
            {
                throw new Exception($"La entidad con código: {productTypeDto.Code} no existe");
            }
            entity.Description = productTypeDto.Description;
            entity.ModifiedDate = DateTime.Now;

            await repository.UpdateAsync(entity);
        }
    }
}
