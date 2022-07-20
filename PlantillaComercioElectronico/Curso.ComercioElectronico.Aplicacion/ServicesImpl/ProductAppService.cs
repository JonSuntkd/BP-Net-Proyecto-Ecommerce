using AutoMapper;
using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Curso.ComercioElectronico.Dominio.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Aplicacion.ServicesImpl
{
    public class ProductAppService : IProductAppService
    {
        private readonly IGenericRepository<Product> repository;
        private readonly IMapper mapper;
        private readonly IValidator<CreateUpdateProductDto> validator;
        public ProductAppService(IGenericRepository<Product> repository, IMapper mapper, IValidator<CreateUpdateProductDto> validator)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task CreateAsync(CreateUpdateProductDto productDto)
        {
            await validator.ValidateAndThrowAsync(productDto);
            var produc = mapper.Map<Product>(productDto);

            produc.Id = Guid.NewGuid();
            produc.CreationDate = DateTime.Now;

            await repository.CreateAsync(produc);
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await repository.GetAsync(id);

            product.IsDeleted = true;
            product.ModifiedDate = DateTime.Now;
            await repository.UpdateAsync(product);
        }

        public async Task<ICollection<ProductDto>> GetAllAsync()
        {
            var query = repository.GetQueryable();

            //Filtrando los no eliminados
            query = query.Where(x => x.IsDeleted == false);

            var result = query.Select(x=> new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Brand = x.Brand.Description,
                ProductType = x.ProductType.Description
            });

            return await result.ToListAsync();
        }

        public async Task<ProductDto> GetAsync(Guid id)
        {
            var query = repository.GetQueryable();

            //Filtrando los no eliminados
            query = query.Where(x => x.IsDeleted == false);

            //Filtrando la informacion por el Id
            query = query.Where(x => x.Id == id);

            var result = query.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Brand = x.Brand.Description,
                ProductType = x.ProductType.Description
            });

            return await result.SingleOrDefaultAsync();
        }

        public async Task<ResultPagination<ProductDto>> GetListAsync(string? searchName = "", string? searchProductType = "", int offset = 0, int limit = 10, string sort = "Name", string order = "asc")
        {
            var query = repository.GetQueryable();

            //Filtrando los no eliminados
            query = query.Where(x => x.IsDeleted == false);

            //Search
            if ((!string.IsNullOrEmpty(searchName)) && (!string.IsNullOrEmpty(searchProductType)))
            {
                query = query.Where(x => ( x.Name.ToUpper().Contains(searchName) && x.ProductType.Description.ToUpper().Contains(searchProductType)));
            }

            //1
            var total =  await query.CountAsync();
            //2
            query = query.Skip(offset).Take(limit);
            //3
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToUpper())
                {
                    case "NAME":
                        query = query.OrderBy(x => x.Name);
                        break;
                    case "PRICE":
                        query = query.OrderBy(x => x.Price);
                        break;
                    default:
                        throw new ArgumentException($"The parameter sort {sort} not sopport");
                }
            }
      

            var queryDto = query.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Brand = x.Brand.Description,
                ProductType = x.ProductType.Description
            });

            var items = await queryDto.ToListAsync();

            var result = new ResultPagination<ProductDto>();
            result.Total = total;
            result.Items = items;
            return result;


        }

        public async Task UpdateAsync(Guid id, CreateUpdateProductDto productDto)
        {
            var product = await repository.GetAsync(id);

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.BrandId = productDto.BrandId;
            product.ProductTypeId = productDto.ProductTypeId;
            product.ModifiedDate = DateTime.Now;
            //var produc = mapper.Map<Product>(productDto);
            //produc.ModifiedDate = DateTime.Now;

            await repository.UpdateAsync(product);
        }
    }
}
