using AutoMapper;
using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Exceptions;
using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Curso.ComercioElectronico.Dominio.Repositories;
using FluentValidation;

namespace Curso.ComercioElectronico.Aplicacion.ServicesImpl
{
    public class ClientInvoiceAppService : IClientInvoiceAppService
    {
        private readonly IGenericRepository<ClientInvoice> repository;
        private readonly IValidator<CreateUpdateClientInvoiceDto> validator;
        private readonly IMapper mapper;

        public ClientInvoiceAppService(IGenericRepository<ClientInvoice> repository, IValidator<CreateUpdateClientInvoiceDto> validator, IMapper mapper)
        {
            this.repository = repository;
            this.validator = validator;
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateUpdateClientInvoiceDto clientInvoiceDto)
        {
            var clientInvoice = mapper.Map<ClientInvoice>(clientInvoiceDto);
            clientInvoice.Id = Guid.NewGuid();

            await repository.CreateAsync(clientInvoice);
        }

        public async Task DeleteAsync(string code)
        {
            var clientInvoice = await repository.GetAsync(code);

            clientInvoice.IsDeleted = true;
            clientInvoice.ModifiedDate = DateTime.Now;
            await repository.UpdateAsync(clientInvoice);
        }

        public async Task<ICollection<ClientInvoiceDto>> GetAllAsync()
        {
            var query = await repository.GetAsync();
            
            var result = query.Select(x => new ClientInvoiceDto
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                IdentificationCard = x.IdentificationCard
            });

            return result.ToList();
        }

        public async Task<ClientInvoiceDto> GetAsync(string code)
        {
            var entity = await repository.GetAsync(code);
            return new ClientInvoiceDto
            {
                Id = entity.Id,
                Name = entity.Name,
                LastName = entity.LastName,
                PhoneNumber = entity.PhoneNumber,
                IdentificationCard = entity.IdentificationCard
            };
        }

        public async Task UpdateAsync(ClientInvoiceDto clientInvoiceDto)
        {
            var entity = await repository.GetAsync(clientInvoiceDto.Id);
            if (entity == null)
            {
                throw new NotFoundException($"La entidad con código: {clientInvoiceDto.Id} no existe");
                //throw new Exception($"La entidad con código: {brandDto.Code} no existe");
            }

            entity.ModifiedDate = DateTime.Now;

            await repository.UpdateAsync(entity);
        }
    }
}
