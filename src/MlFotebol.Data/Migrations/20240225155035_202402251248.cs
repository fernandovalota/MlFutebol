using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MlFutebol.Data.Migrations
{
    /// <inheritdoc />
    public partial class _202402251248 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Suspenso",
                table: "Jogadores",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Jogadores",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.InsertData(
                table: "Itens",
                columns: new[] { "Id", "Nome", "Pontos" },
                values: new object[,]
                {
                    { new Guid("4622a7cf-4440-47ee-bd1b-68a2599f2a8e"), "Chuteira", 4 },
                    { new Guid("49ae7850-3e01-4b5e-88d9-da59ccdb93f7"), "Gatorade", 2 },
                    { new Guid("7d1829a5-c0e4-47a8-9a67-22388b5e7d55"), "Camisa", 1 },
                    { new Guid("b1fd6b3b-6e19-411a-8c03-7922a10da15c"), "Caneleira", 3 }
                });

            migrationBuilder.InsertData(
                table: "Posicoes",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("06b35c37-2786-4862-b4c6-21bfee90088c"), "Lateral Esquerda" },
                    { new Guid("4713a8d0-575a-446a-b2fe-8d54ca012c36"), "Centro Avante" },
                    { new Guid("917b172a-606a-492f-9415-573c60435282"), "Goleiro" },
                    { new Guid("93db8560-eb77-43c6-b66c-9d79d176c6ff"), "Meia" },
                    { new Guid("a281ce90-73e6-424b-8a62-19c7d1d0219d"), "Lateral Direita" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: new Guid("4622a7cf-4440-47ee-bd1b-68a2599f2a8e"));

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: new Guid("49ae7850-3e01-4b5e-88d9-da59ccdb93f7"));

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: new Guid("7d1829a5-c0e4-47a8-9a67-22388b5e7d55"));

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: new Guid("b1fd6b3b-6e19-411a-8c03-7922a10da15c"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("06b35c37-2786-4862-b4c6-21bfee90088c"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("4713a8d0-575a-446a-b2fe-8d54ca012c36"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("917b172a-606a-492f-9415-573c60435282"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("93db8560-eb77-43c6-b66c-9d79d176c6ff"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("a281ce90-73e6-424b-8a62-19c7d1d0219d"));

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Jogadores");

            migrationBuilder.AlterColumn<bool>(
                name: "Suspenso",
                table: "Jogadores",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }
    }
}
