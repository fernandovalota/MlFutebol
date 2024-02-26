using MlFutebol.Bussiness.Entities.Enum;
using MlFutebol.Bussiness.Entities;
using System.ComponentModel.DataAnnotations;

namespace MLFutebol.Api.ViewsModels
{
    public class JogadorViewModel: BaseJogadorViewModel
    {
        public Guid Id { get; set; }
    }
}
