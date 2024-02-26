using MlFutebol.Bussiness.Entities.Enum;
using MlFutebol.Bussiness.Entities;
using System.ComponentModel.DataAnnotations;

namespace MLFutebol.Api.ViewsModels
{
    public class JogadorTrocaItensInventarioViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Id { get; set; }        
        public List<ItemInventarioJogadorViewModel> Inventario { get; set; }
    }
}
