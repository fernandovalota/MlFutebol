using MlFutebol.Bussiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MlFutebol.Bussiness.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adiconar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task Atualizar(TEntity entity);
        Task AtualizarComTransacao(IEnumerable<TEntity> entities);
        Task Remover(Guid id);
        Task RemoverComTransacao(IEnumerable<TEntity> entities);

        /// <summary>
        /// retornar o numero de linhas afetadas
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChanges();


    }
}
