using MlFutebol.Bussiness.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlFutebol.Bussiness.Notification
{
    public class Notificador : INotificador
    {

        /// <summary>
        /// classe inserida pra faciliar e registrar os notificações de problemas para apresentação.
        /// </summary>

        private List<Notificacao> notificacaoList;
        public Notificador()
        {
            notificacaoList = new List<Notificacao>();
        }
        public void Handle(Notificacao notificacao)
        {
            notificacaoList.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return notificacaoList;
        }

        public bool TemNotificacao()
        {
            return notificacaoList.Any();
        }
    }
}
