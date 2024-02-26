
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MlFutebol.Bussiness.Entities;
using System.Reflection.Emit;


namespace MlFutebol.Data.Mappings
{
    public class JogadorMapping : IEntityTypeConfiguration<Jogador>
    {
        public void Configure(EntityTypeBuilder<Jogador> builder)
        {
            builder
                .HasKey(b => b.Id);
            builder
                .Property(b => b.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            ///um jogador possui um time um time possui varios jogadores
            ///para este mapeamento é criada uma propriedade na entidade Time, para não replicar a entidade em banco e exigir transformação
            builder.HasOne(j => j.Time)
                .WithMany(t => t.Jogadores)
                .HasForeignKey(i => i.TimeId); 

            builder.HasOne(j => j.Posicao)
                .WithMany(p => p.Jogadores)
                .HasForeignKey(i => i.PosicaoId); ;

            ///um jogador possui N itens
            builder.HasMany(i => i.Inventario)
                .WithOne(i => i.Jogador)
                .HasForeignKey(i => i.JogadorId);

            builder.Property(p => p.Suspenso)
            .HasDefaultValue(false);

            builder.Property(p => p.Ativo)
            .HasDefaultValue(true);

            builder.ToTable("Jogadores");

        }
    }
}
