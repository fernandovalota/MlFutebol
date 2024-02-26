using Microsoft.EntityFrameworkCore;
using MlFutebol.Bussiness.Entities;
using MlFutebol.Bussiness.Interfaces.Repositories;
using MlFutebol.Data.Context;
using System.Collections.Generic;

namespace MlFutebol.Data.Repository
{
    public class JogadorRepository : Repository<Jogador>, IJogadorRepository
    {
        public JogadorRepository(MlDbContext db) : base(db)
        {
        }

        public async Task<Item> ObterItemPorJogador(Guid jogadorId, Guid itemId)
        {
            return await Db.ItensInventarioJogador
               .Where(iij => iij.JogadorId == jogadorId && iij.ItemId == itemId)
               .Select(p => p.Item)
               .FirstOrDefaultAsync();
        }

        public async Task<Jogador> ObterJogadorCompleto(Guid jogadorId)
        {
            return await Db.Jogadores.AsNoTracking()
                 .Include(i => i.Inventario)
                 .ThenInclude(ii => ii.Item)
                 .Include(p => p.Posicao)
                 .Include(t => t.Time)
                 .FirstOrDefaultAsync(j => j.Id == jogadorId);
        }
        public async Task<Jogador?> ObterJogadorTime(Guid jogadorId)
        {
            return await Db.Jogadores.AsNoTracking()
                  .Include(t => t.Time)
                  .FirstOrDefaultAsync(j => j.Id == jogadorId);
        }
        public async Task<Jogador> ObterJogadorTimeItensInventario(Guid jogadorId)
        {
            var jogador = await Db.Jogadores
          .AsNoTracking()
          .Include(j => j.Posicao)
          .Include(j => j.Time)
          .Include(j => j.Inventario)  // Inclui os itens de inventário diretamente
              .ThenInclude(ii => ii.Item)  // Inclui os itens associados ao inventário
          .FirstOrDefaultAsync(j => j.Id == jogadorId);

            return jogador;
        }
        public async Task<List<ItemInventarioJogador>> ObterItensInventarioJogador(Guid jogadorId)
        {
            return await Db.ItensInventarioJogador.AsNoTracking()
                .Include(i => i.Item)
                .Where(iij => iij.JogadorId == jogadorId)
                .ToListAsync();
        }
        public async Task AtualizarItensInventarioJogador(List<ItemInventarioJogador> itens)
        {
            using (var transaction = await Db.Database.BeginTransactionAsync())
            {
                try
                {
                    // Atualiza todas as entidades na lista
                    Db.ItensInventarioJogador.UpdateRange(itens);

                    await Db.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception("Erro ao atualizar entidades com transação.", ex);
                }
            }
        }
        /// <summary>
        /// necessário criar o método para tratar ItensInventarioJogador
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task RemoverItensInventarioJogador(List<ItemInventarioJogador> items)
        {
            using (var transaction = await Db.Database.BeginTransactionAsync())
            {
                try
                {
                    Db.ItensInventarioJogador.RemoveRange(items);

                    await Db.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception("Erro ao atualizar entidades com transação.", ex);
                }
            }

        }
        public Task<Dictionary<string, decimal>> CalcularMediaItensPorJogador()
        {
            var mediaItensPorJogador = new Dictionary<string, decimal>();

            var jogadores = Db.Jogadores.AsNoTracking()
                .Include(p => p.Inventario)
                .ThenInclude(i => i.Item)
                .ToList();
            var totalJogadores = jogadores.Count;

            var itensPorNome = jogadores.SelectMany(p => p.Inventario)
                            .GroupBy(pi => pi.Item.Nome)
                            .ToDictionary(
                                grp => grp.Key,
                                grp => new
                                {
                                    SomaQuantidades = grp.Sum(pi => pi.Quantidade),
                                    QuantidadeJogadores = totalJogadores
                                })
                            .ToDictionary(
                                kvp => kvp.Key,
                                kvp => decimal.Round((decimal)kvp.Value.SomaQuantidades / kvp.Value.QuantidadeJogadores, 2));

            foreach (var kvp in itensPorNome)
            {
                mediaItensPorJogador.Add(kvp.Key, kvp.Value);
            }

            return Task.FromResult(mediaItensPorJogador);
        }
        public async Task<Dictionary<string, List<string>>> ObterJogadoresSuspensosPorTime()
        {
            var relatorio = await Db.Times.AsNoTracking()
                .Include(t => t.Jogadores)
                .Where(t => t.Jogadores.Any(j => j.Suspenso))
                .ToDictionaryAsync(
                    time => time.Nome,
                    time => time.Jogadores.Where(j => j.Suspenso).Select(j => j.Nome).ToList()
                );

            return relatorio;
        }
        public async Task<Dictionary<string, decimal>> ObterPorcentagemJogadoresAtivosPorTime()
        {
            var relatorio = await Db.Times
                .Include(t => t.Jogadores)
                .ToDictionaryAsync(
                    time => time.Nome,
                    time =>
                    {
                        var jogadorCount = time.Jogadores.Count;
                        if (jogadorCount == 0)
                            return 0.0m; // Caso não haja jogadores, retorne 0%

                        var jogadorAtivoCount = time.Jogadores.Count(j => j.Ativo);
                        return decimal.Round(jogadorAtivoCount / (decimal)jogadorCount * 100, 2);
                    }
                );

            return relatorio;
        }

        public async Task TrocarItensEntreEstoques(List<ItemInventarioJogador> itensOrigem, List<ItemInventarioJogador> itensDestino)
        {
            using (var transaction = await Db.Database.BeginTransactionAsync())
            {
                try
                {
                    await AtualizarItensEntreEstoques(itensOrigem, itensDestino);
                    //await AtualizarQuantidadeRetirada(itensOrigem);
                    await AtualizarItensEntreEstoques(itensDestino, itensOrigem);
                    //await AtualizarQuantidadeRetirada(itensDestino);

                    // Salvar as alterações no banco de dados
                    await Db.SaveChangesAsync();

                    // Confirmar a transação
                    await transaction.CommitAsync();
                }
                catch (DbUpdateException ex)
                {
                    // Lidar com exceções específicas do Entity Framework
                    await transaction.RollbackAsync();
                    throw new Exception($"Erro ao transferir itens entre estoques.{ex.GetBaseException()}", ex);
                }
                catch (Exception ex)
                {
                    // Lidar com exceções genéricas
                    await transaction.RollbackAsync();
                    throw new Exception($"Erro ao transferir itens entre estoques. {ex.GetBaseException()}", ex);
                }
            }
        }

        private async Task AtualizarItensEntreEstoques(List<ItemInventarioJogador> itensOrigem, List<ItemInventarioJogador> itensDestino)
        {
            var jogadorIdOrigem = itensOrigem.FirstOrDefault().JogadorId;
            var jogadorIdDestino = itensDestino.FirstOrDefault().JogadorId;

            // atualizar o estoque destino
            foreach (var itemO in itensOrigem)
            {
                //atualizar quantidade da origem
                
                var itemEstoqueDestino = await Db.ItensInventarioJogador.FirstOrDefaultAsync(i => i.JogadorId == jogadorIdDestino && i.ItemId == itemO.ItemId);
                if (itemEstoqueDestino != null)
                {
                    itemEstoqueDestino.Quantidade += itemO.Quantidade;
                    Db.ItensInventarioJogador.Update(itemEstoqueDestino);
                }
                else
                {
                    itemEstoqueDestino = new ItemInventarioJogador { JogadorId = jogadorIdDestino, ItemId = itemO.ItemId, Quantidade = itemO.Quantidade };
                    Db.ItensInventarioJogador.Add(itemEstoqueDestino);
                }
                var itemEstoqueO = await Db.ItensInventarioJogador.FirstOrDefaultAsync(i => i.JogadorId == jogadorIdOrigem && i.ItemId == itemO.ItemId);
                if (itemEstoqueO != null)
                {
                    itemEstoqueO.Quantidade -= itemO.Quantidade;
                    Db.ItensInventarioJogador.Update(itemEstoqueO);
                }

            }
        }

        private async Task AtualizarQuantidadeRetirada(List<ItemInventarioJogador> itens)
        {
            foreach (var item in itens)
            {
                var itemEstoqueO = await Db.ItensInventarioJogador.FirstOrDefaultAsync(i => i.JogadorId == itens.FirstOrDefault().JogadorId && i.ItemId == item.ItemId);
                if (itemEstoqueO != null) itemEstoqueO.Quantidade -= item.Quantidade;
            }
        }
    }
}
