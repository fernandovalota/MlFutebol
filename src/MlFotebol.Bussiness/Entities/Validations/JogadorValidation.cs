using FluentValidation;
using FluentValidation.Validators;

namespace MlFutebol.Bussiness.Entities.Validations
{
    public class JogadorValidation : AbstractValidator<Jogador>
    {       
        /// <summary>
        /// validações básicas adicionadas para evitar insert de exceptions
        /// </summary>
        public JogadorValidation()
        {
            RuleFor(i => i.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
