using MlFutebol.Bussiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlFutebol.Bussiness.Interfaces.Repositories
{
    public interface ITimeRepository : IRepository<Time>
    {
        Task<List<Time>> ObterTimeJogadores();
    }
}
