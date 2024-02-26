using Microsoft.EntityFrameworkCore;
using MlFutebol.Bussiness.Entities;
using MlFutebol.Bussiness.Interfaces.Repositories;
using MlFutebol.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlFutebol.Data.Repository
{
    public class PosicaoRepository : Repository<Posicao>, IPosicaoRepository
    {
        public PosicaoRepository(MlDbContext db) : base(db)
        {
        }

        public async Task<List<Posicao>> ObterPosicaoJogadores()
        {
            return await Db.Posicoes.AsNoTracking()
                  .Include(t => t.Jogadores).ToListAsync();
        }
    }
}
