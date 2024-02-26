using MlFutebol.Bussiness.Entities;
using MlFutebol.Bussiness.Interfaces.Repositories;
using MlFutebol.Bussiness.Interfaces.Services;
namespace MlFutebol.Bussiness.Services
{
    public class ItemService : BaseService, IItemService
    {
        private readonly IItemRepository itemRepository;
        public ItemService(IItemRepository itemRepository,
            INotificador notificador) : base(notificador)
        {
                this.itemRepository = itemRepository;
        }
        public async Task Adicionar(Item item)
        {
            await itemRepository.Adiconar(item);
        }

        public async Task Atualizar(Item item)
        {
            await itemRepository.Atualizar(item);
        }

        public void Dispose()
        {
            itemRepository?.Dispose();
        }

        public async Task Remover(Guid id)
        {
            await itemRepository.Remover(id);
        }
    }
}
