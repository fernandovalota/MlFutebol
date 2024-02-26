using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MlFutebol.Bussiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlFutebol.Data.Mappings
{
    public class PosicaoMapping : IEntityTypeConfiguration<Posicao>
    {
        public void Configure(EntityTypeBuilder<Posicao> builder)
        {
            builder
                .HasKey(b => b.Id);
            builder
                .Property(b => b.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.HasData(
            new Posicao() { Nome = "Lateral Direita" },
            new Posicao() { Nome = "Centro Avante" },
            new Posicao() { Nome = "Goleiro" },
            new Posicao() { Nome = "Lateral Esquerda" },
            new Posicao() { Nome = "Meia" },
            new Posicao() { Nome = "Zagueiro" },
            new Posicao() { Nome = "Atacante" },
            new Posicao() { Nome = "Meia - Atacante" },
            new Posicao() { Nome = "Volante" });
            builder.ToTable("Posicoes");
        }
    }
}
