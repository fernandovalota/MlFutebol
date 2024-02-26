using MlFutebol.Bussiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlFutebol.Bussiness.Interfaces.Services
{
    public interface ITimeService : IDisposable
    {
        Task Adicionar(Time time);
        Task Atualizar(Time time);
        Task Remover(Guid id);
    }
}
