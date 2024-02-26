﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MlFutebol.Data.Context;

#nullable disable

namespace MlFutebol.Data.Migrations
{
    [DbContext(typeof(MlDbContext))]
    [Migration("20240225165325_202402251352")]
    partial class _202402251352
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MlFutebol.Bussiness.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Pontos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Itens", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("18cae2c1-ab64-49cc-a221-418b2ff86d97"),
                            Nome = "Chuteira",
                            Pontos = 4
                        },
                        new
                        {
                            Id = new Guid("010fbbf9-051b-46f0-a1a2-a7a0065cfe6b"),
                            Nome = "Caneleira",
                            Pontos = 3
                        },
                        new
                        {
                            Id = new Guid("b0bd8fb1-9fa0-4d73-a33c-b3a59ef7e2d4"),
                            Nome = "Gatorade",
                            Pontos = 2
                        },
                        new
                        {
                            Id = new Guid("e208df1e-45cd-45ef-9862-6f0f940fd49c"),
                            Nome = "Camisa",
                            Pontos = 1
                        });
                });

            modelBuilder.Entity("MlFutebol.Bussiness.Entities.ItemInventarioJogador", b =>
                {
                    b.Property<Guid>("JogadorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("JogadorId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItensInventarioJogador", (string)null);
                });

            modelBuilder.Entity("MlFutebol.Bussiness.Entities.Jogador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("CartoesTomados")
                        .HasColumnType("int");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("PosicaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Suspenso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<Guid>("TimeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PosicaoId");

                    b.HasIndex("TimeId");

                    b.ToTable("Jogadores", (string)null);
                });

            modelBuilder.Entity("MlFutebol.Bussiness.Entities.Posicao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Posicoes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f5196ad1-29d0-4d30-8e39-95a69a8ec6f3"),
                            Nome = "Lateral Direita"
                        },
                        new
                        {
                            Id = new Guid("e4807816-282c-41d0-a0b3-9f03c1560323"),
                            Nome = "Centro Avante"
                        },
                        new
                        {
                            Id = new Guid("5a6d80a6-3779-4a48-b97b-f7dbde4ad2af"),
                            Nome = "Goleiro"
                        },
                        new
                        {
                            Id = new Guid("bba324d3-fe29-48f0-9f50-e70e8a2748dd"),
                            Nome = "Lateral Esquerda"
                        },
                        new
                        {
                            Id = new Guid("4fcc5b79-5e98-44c8-84d7-ed6f1e2b3c15"),
                            Nome = "Meia"
                        },
                        new
                        {
                            Id = new Guid("11d80853-27bb-480f-ac27-f798ba328a05"),
                            Nome = "Zagueiro"
                        },
                        new
                        {
                            Id = new Guid("9b49f7dd-7a3b-4559-960c-cab9f07086b3"),
                            Nome = "Atacante"
                        },
                        new
                        {
                            Id = new Guid("f0c122f8-0d5d-480e-82e0-402d3c75633b"),
                            Nome = "Meia - Atacante"
                        },
                        new
                        {
                            Id = new Guid("854d5cc6-091f-4f44-9982-cb74b2f7d35f"),
                            Nome = "Volante"
                        });
                });

            modelBuilder.Entity("MlFutebol.Bussiness.Entities.Time", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Serie")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Times", (string)null);
                });

            modelBuilder.Entity("MlFutebol.Bussiness.Entities.ItemInventarioJogador", b =>
                {
                    b.HasOne("MlFutebol.Bussiness.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .IsRequired();

                    b.HasOne("MlFutebol.Bussiness.Entities.Jogador", "Jogador")
                        .WithMany("Inventario")
                        .HasForeignKey("JogadorId")
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Jogador");
                });

            modelBuilder.Entity("MlFutebol.Bussiness.Entities.Jogador", b =>
                {
                    b.HasOne("MlFutebol.Bussiness.Entities.Posicao", "Posicao")
                        .WithMany("Jogadores")
                        .HasForeignKey("PosicaoId")
                        .IsRequired();

                    b.HasOne("MlFutebol.Bussiness.Entities.Time", "Time")
                        .WithMany("Jogadores")
                        .HasForeignKey("TimeId")
                        .IsRequired();

                    b.Navigation("Posicao");

                    b.Navigation("Time");
                });

            modelBuilder.Entity("MlFutebol.Bussiness.Entities.Jogador", b =>
                {
                    b.Navigation("Inventario");
                });

            modelBuilder.Entity("MlFutebol.Bussiness.Entities.Posicao", b =>
                {
                    b.Navigation("Jogadores");
                });

            modelBuilder.Entity("MlFutebol.Bussiness.Entities.Time", b =>
                {
                    b.Navigation("Jogadores");
                });
#pragma warning restore 612, 618
        }
    }
}
