using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlFutebol.Bussiness.Entities
{
    public class Posicao : Entity
    {
        public string Nome { get; set; }
        /*EF Relation*/
        public List<Jogador> Jogadores { get; set; }

    }
}
