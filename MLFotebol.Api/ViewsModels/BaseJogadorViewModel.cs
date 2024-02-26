using MlFutebol.Bussiness.Entities.Enum;
using MlFutebol.Bussiness.Entities;
using System.ComponentModel.DataAnnotations;

namespace MLFutebol.Api.ViewsModels
{
    public class BaseJogadorViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }
        public int Idade { get; set; }
        public Genero Genero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid PosicaoId { get; set; }
        public string? PosicaoNome { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid TimeId { get; set; }
        public string? TimeNome { get; set; }
        public bool Ativo { get; set; } = true;
        public List<ItemInventarioJogadorViewModel> Inventario { get; set; } = new List<ItemInventarioJogadorViewModel>();
      
    }
}
