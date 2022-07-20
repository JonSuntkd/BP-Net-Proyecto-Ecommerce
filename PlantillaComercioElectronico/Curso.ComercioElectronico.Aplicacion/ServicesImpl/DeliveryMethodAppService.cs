using AutoMapper;
using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Exceptions;
using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Curso.ComercioElectronico.Dominio.Repositories;
using FluentValidation;

namespace Curso.ComercioElectronico.Aplicacion.ServicesImpl
{
    public class DeliveryMethodAppService : IDeliveryMethodAppService
    {
        private readonly IGenericRepository<DeliveryMethod> repository;
        private readonly IValidator<CreateUpdateDeliveryMethodDto> validator;
        private readonly IMapper mapper;

        public DeliveryMethodAppService(IGenericRepository<DeliveryMethod> repository, IValidator<CreateUpdateDeliveryMethodDto> validator, IMapper mapper)
        {
            this.repository = repository;
            this.validator = validator;
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateUpdateDeliveryMethodDto deliveryMethodDto)
        {
            var deliveryMethod = mapper.Map<DeliveryMethod>(deliveryMethodDto);
            deliveryMethod.Id = Guid.NewGuid();
            await repository.CreateAsync(deliveryMethod);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await repository.GetAsync(id);
            if (entity == null)
            {
                throw new NotFoundException($"La entidad con código: {id} no existe");
                //throw new Exception($"La entidad con código: {code} no existe");
            }

            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.Now;

            await repository.UpdateAsync(entity);
        }

        public async Task<ICollection<DeliveryMethodDto>> GetAllAsync()
        {
            var query = await repository.GetAsync();

            var result = query.Select(x => new DeliveryMethodDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            });

            return result.ToList();
        }

        public async Task<DeliveryMethodDto> GetAsync(Guid id)
        {
            var entity = await repository.GetAsync(id);
            return new DeliveryMethodDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
        }

        public async Task UpdateAsync(CreateUpdateDeliveryMethodDto deliveryMethodDto)
        {
            var entity = await repository.GetAsync(deliveryMethodDto.Id);
            if (entity == null)
            {
                throw new NotFoundException($"La entidad con código: {deliveryMethodDto.Id} no existe");
                //throw new Exception($"La entidad con código: {brandDto.Code} no existe");
            }
            entity.Description = deliveryMethodDto.Description;
            entity.ModifiedDate = DateTime.Now;

            await repository.UpdateAsync(entity);
        }
    }
}
