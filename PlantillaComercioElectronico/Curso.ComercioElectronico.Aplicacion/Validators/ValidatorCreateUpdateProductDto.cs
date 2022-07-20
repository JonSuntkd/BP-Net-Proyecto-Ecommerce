using Curso.ComercioElectronico.Aplicacion.Dtos;
using FluentValidation;

namespace Curso.ComercioElectronico.Aplicacion.Validators
{
    public class ValidatorCreateUpdateProductDto : AbstractValidator<CreateUpdateProductDto>
    {
        public ValidatorCreateUpdateProductDto()
        {
            RuleFor(b => b.Name).NotNull().NotEmpty().MaximumLength(10).WithMessage("Nombre muy largo");
            RuleFor(b => b.ProductTypeId).NotNull().NotEmpty().Matches("^[0-9_]*$").WithMessage("Solo ingresa numero");

            //RuleFor(b => b.Code).Matches("^[a-zA-Z0-9-_]*$").WithMessage("Solo numeros, letras y el caracter ( - )");
            //RuleFor(b => b.Description).NotNull().NotEmpty().MaximumLength(200);

        }
    }
}
