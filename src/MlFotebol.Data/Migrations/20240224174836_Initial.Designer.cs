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
    [Migration("20240224174836_Initial")]
    partial class Initial
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
                        .HasColumnType("bit");

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