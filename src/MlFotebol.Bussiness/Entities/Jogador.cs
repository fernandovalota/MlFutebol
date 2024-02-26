
using MlFutebol.Bussiness.Entities.Enum;

namespace MlFutebol.Bussiness.Entities
{
    public class Jogador : Entity
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public Genero Genero { get; set; }
        public Guid PosicaoId { get; set; }
        public Posicao Posicao { get; set; }
        public Guid TimeId { get; set; }
        public Time Time { get; set; }
        public bool Suspenso { get; set; }
        public int CartoesTomados { get; set; }
        public bool Ativo { get; set; }
        /*Ef Realation*/
        public List<ItemInventarioJogador> Inventario { get; set; }
        public Jogador()
        {
            Inventario = new List<ItemInventarioJogador>();
        }

    }
}
