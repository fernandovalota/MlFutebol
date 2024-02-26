using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MlFutebol.Bussiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlFutebol.Data.Mappings
{
    public class ItemMapping : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder
                .HasKey(b => b.Id);
            builder
                .Property(b => b.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.HasData(
            new Item() { Nome = "Chuteira", Pontos = 4 },
            new Item() { Nome = "Caneleira", Pontos = 3 },
            new Item() { Nome = "Gatorade", Pontos = 2 },
            new Item() { Nome = "Camisa", Pontos = 1 }
        );

            builder.ToTable("Itens");

        }
    }
}
