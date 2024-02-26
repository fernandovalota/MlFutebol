using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlFutebol.Bussiness.Entities.Validations
{
    public class PosicaoValidation : AbstractValidator<Posicao>
    {
        public PosicaoValidation()
        {
            RuleFor(j => j.Nome)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
               .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    
    }
}
