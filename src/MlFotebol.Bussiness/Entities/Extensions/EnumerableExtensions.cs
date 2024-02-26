using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlFutebol.Bussiness.Entities.Extensions
{
    public static class EnumerableExtensions
    {       

        public static decimal CalcularValorTotal(this IEnumerable<ItemInventarioJogador> itemInventarioJogador, IEnumerable<Item> item)
        {
            return itemInventarioJogador
                .Where(a => item.Any(b => b.Id == a.ItemId))
                .Sum(a => a.Quantidade * item.First(b => b.Id == a.ItemId).Pontos);
        }

    }
}
