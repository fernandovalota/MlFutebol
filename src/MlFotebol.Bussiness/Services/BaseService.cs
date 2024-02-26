using FluentValidation;
using FluentValidation.Results;
using MlFutebol.Bussiness.Entities;
using MlFutebol.Bussiness.Interfaces.Services;
using MlFutebol.Bussiness.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlFutebol.Bussiness.Services
{
    public abstract class BaseService
    {
        /// <summary>
        /// classe base de serviços.
        /// </summary>
        private readonly INotificador notificador;
        public BaseService(INotificador notificador)
        {
            this.notificador = notificador;
        }
        protected void Notificar(ValidationResult validationResult)
        {
            foreach(var item in validationResult.Errors) {
                Notificar(item.ErrorMessage);
            }
        }
        protected bool ExecutarValidacao<TV , TE>(TV validacao, TE entidade) 
            where TV : AbstractValidator<TE> 
            where TE : Entity
        {
            var validator = validacao.Validate(entidade);
            if (validator.IsValid) return true;
            Notificar(validator);
            return false;
        }

        protected void Notificar (string mensagem)
        {
            notificador.Handle(new Notificacao(mensagem));
        }

        protected bool TemNotificacao()
        {
            return notificador.TemNotificacao();
        }
    }
}
