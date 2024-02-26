using MlFutebol.Bussiness.Entities;
using MlFutebol.Bussiness.Entities.Extensions;
using MlFutebol.Bussiness.Entities.Validations;
using MlFutebol.Bussiness.Interfaces.Repositories;
using MlFutebol.Bussiness.Interfaces.Services;
using System.Collections.Generic;

namespace MlFutebol.Bussiness.Services
{
    public class JogadorService : BaseService, IJogadorService
    {
        private readonly IJogadorRepository jogadorRepository;
        private readonly ITimeRepository timeRepository;
        private readonly IPosicaoRepository posicaoRepository;
        private readonly IItemRepository itemRepository;

        public JogadorService(IJogadorRepository jogadorRepository,
            ITimeRepository timeRepository,
            IPosicaoRepository posicaoRepository,
            IItemRepository itemRepository,
            INotificador notificador) : base(notificador)
        {
            this.jogadorRepository = jogadorRepository;
            this.timeRepository = timeRepository;
            this.posicaoRepository  = posicaoRepository;
            this.itemRepository = itemRepository;
        }

        public async Task Adicionar(Jogador jogador)
        {
            if (!ExecutarValidacao(new JogadorValidation(), jogador)) return;

            if (jogadorRepository.Buscar(j => j.Nome == jogador.Nome).Result.Any())
            {
                Notificar("Já existe um jogador com este nome informado.");                
            }

            // Verificar se o ID do time é válido
            var timeExistente = await timeRepository.ObterPorId(jogador.TimeId);
            if (timeExistente == null)
            {
                Notificar($"ID de time inválido.{jogador.TimeId}");               
            }

            // Verificar se o ID da posição é válido
            var posicaoExistente = await posicaoRepository.ObterPorId(jogador.PosicaoId);
            if (posicaoExistente == null)
            {
                Notificar($"ID de posição inválido.{jogador.PosicaoId}");               
            }

            // Verificar se os IDs dos itens são válidos
            foreach (var itemId in jogador.Inventario)
            {
                var itemExistente = await itemRepository.ObterPorId(itemId.ItemId);
                if (itemExistente == null)
                {
                    Notificar($"ID de item inválido: {itemId.ItemId}");                    
                }
            }

            if (TemNotificacao()) return;
                        
            jogador.Suspenso = false;
            jogador.Ativo = true;
            await jogadorRepository.Adiconar(jogador);
        }
        public async Task Atualizar(Jogador jogador)
        {
            if (!ExecutarValidacao(new JogadorValidation(), jogador)) return;

            var jogadorAtualizar = jogadorRepository.Buscar(j => j.Id == jogador.Id).Result.FirstOrDefault();

            if (jogadorAtualizar == null)
            {
                Notificar($"Jogador {jogador.Nome} não encontrado.");
                return;
            }
            ///regra para não atualizar time que será realizada separadamente
            ///regra para não atualizar cartões amarelos que será realizada separadamente
            // Atualizar a quantidade dos itens de inventário com base na lista recebida pela API
            foreach (var itemNovo in jogador.Inventario)
            {
                var itemExistente = jogadorAtualizar.Inventario.FirstOrDefault(i => i.ItemId == itemNovo.ItemId);
                if (itemExistente != null)
                {                    
                    itemExistente.Quantidade = itemNovo.Quantidade;
                }
                else
                {
                    jogadorAtualizar.Inventario.Add(itemNovo);
                }
            }
            jogadorAtualizar.Nome = jogador.Nome;
            jogadorAtualizar.Genero = jogador.Genero;
            jogadorAtualizar.Idade = jogador.Idade;
            jogadorAtualizar.PosicaoId = jogador.PosicaoId;
            await jogadorRepository.Atualizar(jogadorAtualizar);
        }
        public async Task LiberarJogadorSuspenso(Guid id)
        {
            var jogador = await jogadorRepository.ObterPorId(id);
            if (jogador == null)
            {
                Notificar("Jogador não encontrado.");
                return;
            }
            jogador.CartoesTomados = 0;
            jogador.Suspenso = false;
            await jogadorRepository.Atualizar(jogador);
        }
        public async Task Remover(Guid id)
        {
            var jogador = await jogadorRepository.ObterPorId(id);
            if (jogador == null)
            {
                Notificar("Jogador não existe!");
                return;
            }
            if (jogador.Inventario.Any())
            {
                Notificar("O jogador possui inventário cadastrados!");
                return;
            }

            await jogadorRepository.Remover(id);
        }
        /// <summary>
        /// prepara a troca de itens no inventario
        /// </summary>
        /// <param name="entityJogadorOrigem">jogador que será retirado itens</param>
        /// <param name="entityJogadorDestino">jogador que será inserido itens</param>
        /// <param name="itemInventarioOrigem">itens selecionados enviado pela api</param>
        private void TrocarItensInventario(Jogador entityJogadorOrigem, Jogador entityJogadorDestino, List<ItemInventarioJogador> itemInventarioOrigem)
        {
            foreach (var item in itemInventarioOrigem)
            {
                var itemD = entityJogadorDestino.Inventario.Where(i => i.Item.Id == item.ItemId).FirstOrDefault();
                if (itemD != null)
                {
                    itemD.Quantidade += item.Quantidade;
                }
                else
                {
                    entityJogadorDestino.Inventario.Add(item);
                }
                var itemO = entityJogadorOrigem.Inventario.Where(i => i.Item.Id == item.ItemId).FirstOrDefault();
                if (itemO != null)
                {
                    itemO.Quantidade -= item.Quantidade;
                }
            }
        }
        public async Task NegociarItens(Jogador jogadorOrigem, Jogador jogadorDestino)
        {
            var jogadorOrigBaseAtual = await jogadorRepository.ObterPorId(jogadorOrigem.Id);
            var jogadorDestBaseAtual = await jogadorRepository.ObterPorId(jogadorDestino.Id);
            
            if (jogadorOrigBaseAtual == null || jogadorDestBaseAtual == null)
            {
                Notificar($"Jogador {(jogadorOrigBaseAtual == null ? jogadorOrigem.Id : jogadorDestino.Id)} não encontrado.");                
            }
            
            if (jogadorOrigBaseAtual.Suspenso || jogadorDestBaseAtual.Suspenso)
            {
                Notificar($"Jogador {(jogadorOrigBaseAtual.Suspenso ? jogadorOrigBaseAtual.Nome : jogadorDestBaseAtual.Nome)} suspenso, impedido de negociar.");
            }

            foreach (var item in jogadorOrigem.Inventario)
            {
                item.Item = await jogadorRepository.ObterItemPorJogador(item.JogadorId, item.ItemId);
            }

            foreach (var item in jogadorDestino.Inventario)
            {
                item.Item = await jogadorRepository.ObterItemPorJogador(item.JogadorId, item.ItemId);
            }

            if (jogadorOrigem.Inventario.CalcularValoresTotais() != jogadorDestino.Inventario.CalcularValoresTotais())
            {
                Notificar($"Pontos entre os jogadores diferentes, impedido de negociar.");                
            }

            if (TemNotificacao()) return;

            //TrocarItensInventario(jogadorOrigBaseAtual, jogadorDestBaseAtual, jogadorOrigem.Inventario);
            //TrocarItensInventario(jogadorDestBaseAtual, jogadorOrigBaseAtual, jogadorDestino.Inventario);

            //var atualizar = new List<Jogador>
            //{
            //    jogadorDestBaseAtual,
            //    jogadorOrigBaseAtual
            //};
            await jogadorRepository.TrocarItensEntreEstoques(jogadorOrigem.Inventario, jogadorDestino.Inventario);
        }
        public async Task LancarCartaoAmarelo(Guid id)
        {
            var jogador = await jogadorRepository.ObterPorId(id);
            if (jogador == null)
            {
                Notificar("Jogador não encontrado.");                
            }
            if (jogador.Suspenso)
            {
                Notificar("Jogador já suspenso.");
            }
            if (TemNotificacao()) return;
            jogador.CartoesTomados += 1;
            jogador.Suspenso = jogador.CartoesTomados == 3;
            await jogadorRepository.Atualizar(jogador);
        }
        public async Task TrocaDeTime(Guid idJogador, Guid novoTimeId)
        {
            var jogador = await jogadorRepository.ObterPorId(idJogador);
            var novoTime = await timeRepository.ObterPorId(novoTimeId);

            if (jogador == null || novoTime == null)
            {
                Notificar($"{(jogador == null ? "Jogador" : "Novo Time")} não encontrado.");
                return;
            }

            jogador.Time = novoTime;
            await jogadorRepository.Atualizar(jogador);
        }

        public Task<Jogador> ObterJogadorCompleto(Guid jogadorId)
        {
            return jogadorRepository.ObterJogadorCompleto(jogadorId);
        }        

        public async Task<Dictionary<string, List<string>>> ObterJogadoresSuspensosPorTime()
        {
            return await jogadorRepository.ObterJogadoresSuspensosPorTime();
        }

        public async Task<Dictionary<string, decimal>> CalcularMediaItensPorJogador()
        {
            return await jogadorRepository.CalcularMediaItensPorJogador();
        }

        public async Task<Dictionary<string, decimal>> ObterPorcentagemJogadoresAtivosPorTime()
        {
            return await jogadorRepository.ObterPorcentagemJogadoresAtivosPorTime();
        }
        public void Dispose()
        {
            jogadorRepository?.Dispose();
        }
    }
}
