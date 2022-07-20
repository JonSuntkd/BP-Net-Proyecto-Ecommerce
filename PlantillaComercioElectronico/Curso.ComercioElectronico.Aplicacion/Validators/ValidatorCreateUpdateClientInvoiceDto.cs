using Curso.ComercioElectronico.Aplicacion.Dtos;
using FluentValidation;

namespace Curso.ComercioElectronico.Aplicacion.Validators
{
    public class ValidatorCreateUpdateClientInvoiceDto : AbstractValidator<CreateUpdateClientInvoiceDto>
    {
        public ValidatorCreateUpdateClientInvoiceDto()
        {
            //RuleFor(b => b.Code).NotNull().NotEmpty().MaximumLength(4).WithMessage("Error en el codigo maximo 4");
            //RuleFor(b => b.Code).Matches("^[a-zA-Z0-9-_]*$").WithMessage("Solo numeros, letras y el caracter ( - )");
            //RuleFor(b => b).NotNull().NotEmpty().MaximumLength(200);

        }
    }
}
