using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MlFutebol.Bussiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace MlFutebol.Data.Mappings
{
    public class ItemInventarioJogadorMapping : IEntityTypeConfiguration<ItemInventarioJogador>
    {
        public void Configure(EntityTypeBuilder<ItemInventarioJogador> builder)
        {
            builder
            .HasKey(iij => new { iij.JogadorId, iij.ItemId });

            // Relacionamento com Jogador
            builder
                .HasOne(iij => iij.Jogador)
                .WithMany(j => j.Inventario)
                .HasForeignKey(iij => iij.JogadorId);

            // Relacionamento com item
           builder
                .HasOne(iij => iij.Item)
                .WithMany()
                .HasForeignKey(iij => iij.ItemId);


            builder.ToTable("ItensInventarioJogador");

        }

    }
}
