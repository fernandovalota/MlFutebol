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
    [Migration("20240225155035_202402251248")]
    partial class _202402251248
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
                            Id = new Guid("4622a7cf-4440-47ee-bd1b-68a2599f2a8e"),
                            Nome = "Chuteira",
                            Pontos = 4
                        },
                        new
                        {
                            Id = new Guid("b1fd6b3b-6e19-411a-8c03-7922a10da15c"),
                            Nome = "Caneleira",
                            Pontos = 3
                        },
                        new
                        {
                            Id = new Guid("49ae7850-3e01-4b5e-88d9-da59ccdb93f7"),
                            Nome = "Gatorade",
                            Pontos = 2
                        },
                        new
                        {
                            Id = new Guid("7d1829a5-c0e4-47a8-9a67-22388b5e7d55"),
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
                            Id = new Guid("a281ce90-73e6-424b-8a62-19c7d1d0219d"),
                            Nome = "Lateral Direita"
                        },
                        new
                        {
                            Id = new Guid("4713a8d0-575a-446a-b2fe-8d54ca012c36"),
                            Nome = "Centro Avante"
                        },
                        new
                        {
                            Id = new Guid("917b172a-606a-492f-9415-573c60435282"),
                            Nome = "Goleiro"
                        },
                        new
                        {
                            Id = new Guid("06b35c37-2786-4862-b4c6-21bfee90088c"),
                            Nome = "Lateral Esquerda"
                        },
                        new
                        {
                            Id = new Guid("93db8560-eb77-43c6-b66c-9d79d176c6ff"),
                            Nome = "Meia"
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
