using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlFutebol.Bussiness.Entities
{
    public class ItemInventarioJogador 
    {
        //mapemento iteminventario nao existe sem item e jogador
        public Guid JogadorId { get; set; }
        public Guid ItemId { get; set; }
        public int Quantidade { get; set; }

        /*Ef Realation*/
        public Jogador Jogador { get; set; }
        public Item Item { get; set; }
    }
}
