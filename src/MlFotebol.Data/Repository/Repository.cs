using Microsoft.EntityFrameworkCore;
using MlFutebol.Bussiness.Entities;
using MlFutebol.Bussiness.Interfaces.Repositories;
using MlFutebol.Data.Context;
using System.Linq.Expressions;

namespace MlFutebol.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MlDbContext Db;
        //atalho para acionar o dbset sem precisar falar a entidade
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(MlDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        /// <summary>
        /// mesmo com o notracking desligado nas configurações, por ser uma busca, auxilia na performance.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adiconar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task AtualizarComTransacao(IEnumerable<TEntity> entities)
        {
            using (var transaction = await Db.Database.BeginTransactionAsync())
            {
                try
                {
                    // Desanexa as entidades do contexto antes de atualizar
                    foreach (var entity in entities)
                    {
                        Db.Entry(entity).State = EntityState.Detached;
                    }

                    // Atualiza todas as entidades na lista
                    DbSet.UpdateRange(entities);

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

        public async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }
        public virtual async Task RemoverComTransacao(IEnumerable<TEntity> entities)
        {
            using (var transaction = await Db.Database.BeginTransactionAsync())
            {
                try
                {
                    
                    DbSet.RemoveRange(entities);

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

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
