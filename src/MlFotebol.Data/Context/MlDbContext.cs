using Microsoft.EntityFrameworkCore;
using MlFutebol.Bussiness.Entities;

namespace MlFutebol.Data.Context
{
    public class MlDbContext: DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options">injetar para repassar para a classe basica dbcontext</param>
        public MlDbContext(DbContextOptions<MlDbContext> options):base(options) 
        {
            ///comportamento de tracking
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ///apoia o mapeamento da viewmodel (em tela), no retorno com a perda do tracking, evitando o problema de concorrencia.
            ///em resumo a volta da viewmodel para a model de banco, evita o erro de duas pessoas altera a mesma model
            ///a função seria ativa somente se a alteração fosse diretament na dto.
            ChangeTracker.AutoDetectChangesEnabled = false;

            ///evitar problemas de persinstência de data
            
        }

        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Posicao> Posicoes { get; set; }
        public DbSet<ItemInventarioJogador> ItensInventarioJogador { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///setar strings não mapeadas para varchr de 100
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");
            
            ///adiciona qualquer mapeamento realizado na inicialização, uma única vez.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MlDbContext).Assembly);
            ///percorre todo contexto e seta o comportamento DeleteBehavior par null, não permitindo a deleção em cascata
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e=>e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }


    }
}
