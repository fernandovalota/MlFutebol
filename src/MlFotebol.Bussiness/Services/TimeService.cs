using MlFutebol.Bussiness.Entities;
using MlFutebol.Bussiness.Interfaces.Repositories;
using MlFutebol.Bussiness.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlFutebol.Bussiness.Services
{
    internal class TimeService : BaseService, ITimeService
    {
        private readonly ITimeRepository timeRepository;
        public TimeService(ITimeRepository timeRepository,
            INotificador notificador):base(notificador) 
        {
            this.timeRepository = timeRepository;
        }

        public async Task Adicionar(Time time)
        {
            await timeRepository.Adiconar(time);
        }

        public async Task Atualizar(Time time)
        {
            await timeRepository.Atualizar(time);
        }

        public void Dispose()
        {
            timeRepository?.Dispose();
        }

        public async Task Remover(Guid id)
        {
            await timeRepository.Remover(id);
        }
    }
}
