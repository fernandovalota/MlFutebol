using FluentValidation;
using FluentValidation.Validators;

namespace MlFutebol.Bussiness.Entities.Validations
{
    public class ItemValidation : AbstractValidator<Item>
    {
        /// <summary>
        /// validações básicas adicionadas para evitar insert de exceptions
        /// </summary>
        public ItemValidation()
        {
            RuleFor(j=> j.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2,200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
