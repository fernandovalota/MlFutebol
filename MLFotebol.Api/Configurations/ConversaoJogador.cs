using MLFutebol.Api.ViewsModels;
using MlFutebol.Bussiness.Entities;

namespace MLFutebol.Api.Configurations
{
    public class ConversaoJogador
    {
        public static Jogador MapearJogadorViewModelParaEntidade(BaseJogadorViewModel jogadorViewModel)
        {
            var jogador = new Jogador
            {
                Nome = jogadorViewModel.Nome,
                Idade = jogadorViewModel.Idade,
                Genero = jogadorViewModel.Genero,
                PosicaoId = jogadorViewModel.PosicaoId,
                TimeId = jogadorViewModel.TimeId,
                Ativo = jogadorViewModel.Ativo
            };

            if (jogadorViewModel.Inventario != null)
            {
                jogador.Inventario = jogadorViewModel.Inventario
                    .Select(itemViewModel => new ItemInventarioJogador
                    {
                        JogadorId = jogador.Id,
                        ItemId = itemViewModel.ItemId,
                        Quantidade = itemViewModel.Quantidade
                    })
                    .ToList();
            }

            return jogador;
        }
    }
}
