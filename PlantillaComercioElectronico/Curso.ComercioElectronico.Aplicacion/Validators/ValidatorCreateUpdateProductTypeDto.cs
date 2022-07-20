using Curso.ComercioElectronico.Aplicacion.Dtos;
using FluentValidation;

namespace Curso.ComercioElectronico.Aplicacion.Validators
{
    public class ValidatorCreateUpdateProductTypeDto : AbstractValidator<CreateUpdateProductTypeDto>
    {
        public ValidatorCreateUpdateProductTypeDto()
        {
            RuleFor(b => b.Description).NotNull().NotEmpty().Matches("^[a-zA-Z_]*$").WithMessage("Solo acepta letras");
        }
    }
}
