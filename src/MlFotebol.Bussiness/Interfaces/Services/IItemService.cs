using MlFutebol.Bussiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlFutebol.Bussiness.Interfaces.Services
{
    public interface IItemService : IDisposable
    {
        Task Adicionar(Item item);
        Task Atualizar(Item item);
        Task Remover(Guid id);

    }
}
