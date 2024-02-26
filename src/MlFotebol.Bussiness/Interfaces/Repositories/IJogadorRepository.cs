using MlFutebol.Bussiness.Entities;

namespace MlFutebol.Bussiness.Interfaces.Repositories
{
    public interface IJogadorRepository : IRepository<Jogador>
    {
        Task<Item> ObterItemPorJogador(Guid jogadorId, Guid itemId);
        Task<List<ItemInventarioJogador>> ObterItensInventarioJogador(Guid jogadorId);
        Task<Jogador> ObterJogadorTime(Guid jogadorId);
        Task<Jogador> ObterJogadorTimeItensInventario(Guid jogadorId);
        Task<Jogador> ObterJogadorCompleto(Guid jogadorId);
        Task AtualizarItensInventarioJogador(List<ItemInventarioJogador> itens);
        Task RemoverItensInventarioJogador(List<ItemInventarioJogador> items);
        Task<Dictionary<string, decimal>> CalcularMediaItensPorJogador();
        Task<Dictionary<string, List<string>>> ObterJogadoresSuspensosPorTime();
        Task<Dictionary<string, decimal>> ObterPorcentagemJogadoresAtivosPorTime();
        Task TrocarItensEntreEstoques(List<ItemInventarioJogador> itensOrigem, List<ItemInventarioJogador> itensDestino);
    }
}
