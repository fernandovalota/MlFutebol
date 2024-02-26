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
    public class TimeRepository : Repository<Time>, ITimeRepository
    {
        public TimeRepository(MlDbContext db) : base(db)
        {
        }

        public async Task<List<Time>> ObterTimeJogadores()
        {
            return await Db.Times.AsNoTracking()
                  .Include(t => t.Jogadores).ToListAsync();
        }
    }
}
