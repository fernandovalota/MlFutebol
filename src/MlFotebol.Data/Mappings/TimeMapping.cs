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
    public class TimeMapping : IEntityTypeConfiguration<Time>
    {
        public void Configure(EntityTypeBuilder<Time> builder)
        {
            builder
                .HasKey(b => b.Id);
            builder
                .Property(b => b.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");
            builder.HasData(
            new Time() { Nome = "Corinthians", Serie = "A" },
            new Time() { Nome = "São Paulo", Serie = "A" },
            new Time() { Nome = "Palmeiras", Serie = "A" },
            new Time() { Nome = "Santos", Serie = "B" },
            new Time() { Nome = "Ituano", Serie = "B" },
            new Time() { Nome = "Gremio Prudente", Serie = "B" },
            new Time() { Nome = "Varzea", Serie = "C" },
            new Time() { Nome = "Canarinho", Serie = "C" },
            new Time() { Nome = "Vasco", Serie = "C" });
            builder.ToTable("Times");

        }
    
    }
}
