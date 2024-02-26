using MlFutebol.Bussiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlFutebol.Bussiness.Interfaces.Repositories
{
    public interface IPosicaoRepository : IRepository<Posicao>
    {
        Task<List<Posicao>> ObterPosicaoJogadores();
    }
}
