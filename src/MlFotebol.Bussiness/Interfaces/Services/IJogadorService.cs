using MlFutebol.Bussiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlFutebol.Bussiness.Interfaces.Services
{
    public interface IJogadorService : IDisposable
    {
        Task Adicionar(Jogador jogador);
        Task Atualizar(Jogador jogador);
        Task Remover(Guid id);
        Task LancarCartaoAmarelo(Guid id);
        Task LiberarJogadorSuspenso(Guid id);
        Task NegociarItens(Jogador jogadorOrigem, Jogador jogadorDestino);
        Task TrocaDeTime(Guid idJogador, Guid novoTimeId);
        Task<Jogador> ObterJogadorCompleto(Guid jogadorId);
        Task<Dictionary<string, List<string>>> ObterJogadoresSuspensosPorTime();
        Task<Dictionary<string, decimal>> CalcularMediaItensPorJogador();
        Task<Dictionary<string, decimal>> ObterPorcentagemJogadoresAtivosPorTime();
    }
}
