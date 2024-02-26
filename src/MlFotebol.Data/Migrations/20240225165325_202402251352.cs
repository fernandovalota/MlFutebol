using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MlFutebol.Data.Migrations
{
    /// <inheritdoc />
    public partial class _202402251352 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Itens",
                columns: new[] { "Id", "Nome", "Pontos" },
                values: new object[,]
                {
                    { new Guid("010fbbf9-051b-46f0-a1a2-a7a0065cfe6b"), "Caneleira", 3 },
                    { new Guid("18cae2c1-ab64-49cc-a221-418b2ff86d97"), "Chuteira", 4 },
                    { new Guid("b0bd8fb1-9fa0-4d73-a33c-b3a59ef7e2d4"), "Gatorade", 2 },
                    { new Guid("e208df1e-45cd-45ef-9862-6f0f940fd49c"), "Camisa", 1 }
                });

            migrationBuilder.InsertData(
                table: "Posicoes",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("11d80853-27bb-480f-ac27-f798ba328a05"), "Zagueiro" },
                    { new Guid("4fcc5b79-5e98-44c8-84d7-ed6f1e2b3c15"), "Meia" },
                    { new Guid("5a6d80a6-3779-4a48-b97b-f7dbde4ad2af"), "Goleiro" },
                    { new Guid("854d5cc6-091f-4f44-9982-cb74b2f7d35f"), "Volante" },
                    { new Guid("9b49f7dd-7a3b-4559-960c-cab9f07086b3"), "Atacante" },
                    { new Guid("bba324d3-fe29-48f0-9f50-e70e8a2748dd"), "Lateral Esquerda" },
                    { new Guid("e4807816-282c-41d0-a0b3-9f03c1560323"), "Centro Avante" },
                    { new Guid("f0c122f8-0d5d-480e-82e0-402d3c75633b"), "Meia - Atacante" },
                    { new Guid("f5196ad1-29d0-4d30-8e39-95a69a8ec6f3"), "Lateral Direita" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: new Guid("010fbbf9-051b-46f0-a1a2-a7a0065cfe6b"));

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: new Guid("18cae2c1-ab64-49cc-a221-418b2ff86d97"));

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: new Guid("b0bd8fb1-9fa0-4d73-a33c-b3a59ef7e2d4"));

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: new Guid("e208df1e-45cd-45ef-9862-6f0f940fd49c"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("11d80853-27bb-480f-ac27-f798ba328a05"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("4fcc5b79-5e98-44c8-84d7-ed6f1e2b3c15"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("5a6d80a6-3779-4a48-b97b-f7dbde4ad2af"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("854d5cc6-091f-4f44-9982-cb74b2f7d35f"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("9b49f7dd-7a3b-4559-960c-cab9f07086b3"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("bba324d3-fe29-48f0-9f50-e70e8a2748dd"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("e4807816-282c-41d0-a0b3-9f03c1560323"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("f0c122f8-0d5d-480e-82e0-402d3c75633b"));

            migrationBuilder.DeleteData(
                table: "Posicoes",
                keyColumn: "Id",
                keyValue: new Guid("f5196ad1-29d0-4d30-8e39-95a69a8ec6f3"));

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
    }
}
