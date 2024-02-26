using MlFutebol.Bussiness.Entities;

namespace MLFutebol.Api.ViewsModels
{
    public class BaseItemInventarioJogadorViewModel
    {
        public Guid ItemId { get; set; }
        public string? Nome { get; set; }
        public int Quantidade { get; set; }
    }
}
