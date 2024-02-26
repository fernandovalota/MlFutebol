using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlFutebol.Bussiness.Entities.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// classe de extensões para apoio
        /// </summary>
        /// <param name="itens"></param>
        /// <returns></returns>
        public static int CalcularPontosTotais(this List<Item> itens)
        {
            return itens.Sum(i => i.Pontos);
        }
        public static int CalcularValoresTotais(this List<ItemInventarioJogador> itens)
        {
            return itens.Sum(i => i.Item.Pontos * i.Quantidade);
        }
    }
}
